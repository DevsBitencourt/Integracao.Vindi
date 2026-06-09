# Integração Vindi

> SDK .NET Standard para integração com a [API de Recorrência da Vindi](https://vindi.github.io/api-docs/dist/)

[![.NET Standard](https://img.shields.io/badge/.NET_Standard-2.1-512BD4?style=flat-square&logo=dotnet)](https://docs.microsoft.com/dotnet/standard/net-standard)
[![C#](https://img.shields.io/badge/C%23-12-239120?style=flat-square&logo=csharp)](https://docs.microsoft.com/dotnet/csharp/)
[![License](https://img.shields.io/badge/license-MIT-green?style=flat-square)](./LICENSE)

---

## Visão Geral

SDK .NET para consumo da API Vindi com suporte a injeção de dependência via `IHttpClientFactory`, tratamento estruturado de exceções e sistema de filtros de consulta fluente.

```
Integracao.Vindi/
├── IntegracaoVindi          → Biblioteca principal
└── IntegracaoVindi.Tests    → Testes unitários
```

---

## Instalação

```bash
dotnet add package IntegracaoVindi
```

---

## Configuração

### ASP.NET Core / .NET 6+

```csharp
// Program.cs
builder.Services.AddHttpClient("vindi", client =>
{
    client.BaseAddress = new Uri("https://app.vindi.com.br/");
});

builder.Services.AddTransient<ICustomerService, CustomerService>();
```

### .NET Standard / Console

```csharp
var services = new ServiceCollection();

services.AddHttpClient("vindi", client =>
{
    client.BaseAddress = new Uri("https://app.vindi.com.br/");
});

services.AddTransient<ICustomerService, CustomerService>();

var provider = services.BuildServiceProvider();
```

---

## Utilização

### Configurar credenciais

```csharp
var customerService = provider.GetRequiredService<ICustomerService>();
customerService.SetCredentials("SUA_API_KEY:");
```

### Listar clientes

```csharp
var response = await customerService.GetAll();

if (response.Success)
    foreach (var customer in response.Data.Customers)
        Console.WriteLine(customer.Name);
```

### Filtros de consulta

```csharp
var response = await customerService.GetAll(
    new QueryFilter { Field = "status",     Value = "active",     Operator = FilterOperator.Equals },
    new QueryFilter { Field = "created_at", Value = "2024-01-01", Operator = FilterOperator.GreaterThan }
);
```

### CRUD completo

```csharp
// Buscar por ID
var response = await customerService.GetById("123456");

// Criar
var created = await customerService.Create(new Customer
{
    Name  = "João Silva",
    Email = "joao@email.com",
    RegistryCode = "123.456.789-00"
});

// Atualizar
var updated = await customerService.Update(new Customer { Id = 123, Name = "João Atualizado" });

// Remover
var deleted = await customerService.Delete("123456");
```

---

## Tratamento de Exceções

```csharp
try
{
    var response = await customerService.GetById("123");
}
catch (IntegrationCredentialsException ex)
{
    // Credenciais ausentes (antes da requisição) ou token inválido (HTTP 401/403)
    Console.WriteLine($"Credencial: {ex.Message}");
}
catch (IntegrationException ex)
{
    Console.WriteLine($"Erro [{ex.StatusCode}]: {ex.Message}");
}
```

---

## Recursos Disponíveis

| Interface | Método | Verbo HTTP | Descrição |
|---|---|---|---|
| `ICustomerService` | `GetAll(filters)` | GET | Lista clientes com filtros opcionais |
| `ICustomerService` | `GetById(id)` | GET | Busca cliente por ID |
| `ICustomerService` | `Create(customer)` | POST | Cria novo cliente |
| `ICustomerService` | `Update(customer)` | PUT | Atualiza cliente existente |
| `ICustomerService` | `Delete(id)` | DELETE | Remove um cliente |

---

## Estrutura do Projeto

```
IntegracaoVindi/
├── Infrastructure/
│   └── Exceptions/
│       ├── IntegrationException.cs
│       └── IntegrationCredentialsException.cs
└── Services/
    ├── Builders/
    │   └── QueryBuilder.cs
    ├── Enums/
    │   ├── FilterOperator.cs
    │   └── ConditionalOperator.cs
    ├── Filters/
    │   └── QueryFilter.cs
    ├── Handlers/
    │   └── IntegrationExceptionHandler.cs
    ├── Models/
    │   └── Response.cs
    └── Vindi.Api/
        ├── VindiClient.cs
        ├── IVindiClient.cs
        ├── Enums/VindiRoute.cs
        ├── Helpers/RouteHelper.cs
        ├── Models/
        │   ├── Address.cs
        │   └── Phone.cs
        └── Customers/
            ├── CustomerService.cs
            ├── ICustomerService.cs
            └── Models/
                ├── Customer.cs
                └── Customers.cs
```

---

## Pré-requisitos

- .NET Standard 2.1+
- `Microsoft.Extensions.Http`
- `Microsoft.Extensions.DependencyInjection`
- `Newtonsoft.Json` >= 13.0

---

## Sandbox

```csharp
client.BaseAddress = new Uri("https://sandbox-app.vindi.com.br/");
```

Crie uma conta sandbox em [app.vindi.com.br](https://app.vindi.com.br).

---

## Licença

MIT — veja [LICENSE](./LICENSE) para mais detalhes.