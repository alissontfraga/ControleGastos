# Sistema de Controle de Gastos Residenciais

Projeto desenvolvido como solução para um desafio técnico utilizando **.NET**, **ASP.NET Core Web API**, **React** e **TypeScript**.

O sistema permite o gerenciamento de pessoas, transações financeiras e consulta de totais, seguindo as regras de negócio propostas.

---

# Tecnologias utilizadas

## Backend

- .NET 10
- ASP.NET Core Web API
- C#
- Entity Framework Core
- PostgreSQL
- Swagger

## Frontend

- React
- TypeScript

---

# Funcionalidades

## Cadastro de pessoas

- Criar pessoa
- Listar pessoas
- Buscar pessoa por ID
- Remover pessoa

Ao remover uma pessoa, todas as suas transações também são removidas automaticamente.

---

## Cadastro de transações

- Criar transação
- Listar transações
- Buscar transação por ID

### Regras de negócio

- A pessoa informada deve existir.
- Pessoas menores de 18 anos podem cadastrar apenas despesas.

---

## Relatórios

Consulta contendo:

- Total de receitas por pessoa;
- Total de despesas por pessoa;
- Saldo por pessoa;
- Total geral de receitas;
- Total geral de despesas;
- Saldo geral.

---

# Estrutura do projeto

```text
ControleGastos.API
│
├── Controllers
├── Data
├── DTOs
    └── Pessoas
    └── Relatorios
    └── Transacoes
├── Enums
├── Exceptions
├── Models
├── Services
│   └── Interfaces
├── Migrations
└── Program.cs
```

---

# Pré-requisitos

- .NET SDK 10
- Docker Desktop

---

# Como executar

### 1. Clone o repositório

```bash
git clone <https://github.com/alissontfraga/ControleGastos.git>
```

### 2. Acesse a pasta do projeto

```bash
cd ControleGastos
```

### 3. Inicie o banco de dados

```bash
docker compose up -d
```

### 4. Aplique as migrations

```bash
dotnet ef database update
```

### 5. Execute a API

```bash
dotnet run
```

---

# Swagger

Após iniciar a aplicação, acesse:

```
https://localhost:5174/swagger
```

> A porta pode variar de acordo com a configuração do projeto.

---

# Principais regras de negócio

- Pessoas menores de idade podem cadastrar apenas despesas.
- Toda transação deve estar vinculada a uma pessoa existente.
- Ao excluir uma pessoa, todas as suas transações são removidas automaticamente.
- O sistema calcula automaticamente receitas, despesas e saldo por pessoa, além dos totais gerais.

---

# Tratamento de erros

A API utiliza um tratamento global de exceções através do `IExceptionHandler`.

Exceções implementadas:

| Exceção | Código HTTP | Descrição |
|---------|:-----------:|-----------|
| `NotFoundException` | 404 | Recurso não encontrado. |
| `BusinessException` | 400 | Violação de regra de negócio. |
| Demais exceções | 500 | Erro interno inesperado. |

---

# Comandos úteis

Iniciar o banco:

```bash
docker compose up -d
```

Parar o banco:

```bash
docker compose down
```

Aplicar migrations:

```bash
dotnet ef database update
```

Executar a API:

```bash
dotnet run
```

---

