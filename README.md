# TaskManager API

API REST para gerenciamento de tarefas, desenvolvida em C# com ASP.NET Core.

## Tecnologias

- C#
- ASP.NET Core Web API
- Swagger

## Estrutura

O projeto é dividido em três camadas:

| Projeto | Responsabilidade |
|---|---|
| `TaskManager.API` | Controllers e configuração da aplicação |
| `TaskManager.Services` | Regras de negócio (UseCases), validações e armazenamento |
| `TaskManager.Communication` | Requests, Responses e Enums |

## Endpoints

| Método | Rota | Descrição | Sucesso |
|---|---|---|---|
| POST | `/api/tasks` | Cria uma tarefa | 201 |
| GET | `/api/tasks` | Lista todas as tarefas | 200 |
| GET | `/api/tasks/{id}` | Busca uma tarefa pelo Id | 200 |
| PUT | `/api/tasks/{id}` | Atualiza uma tarefa | 200 |
| DELETE | `/api/tasks/{id}` | Exclui uma tarefa | 204 |

Erros retornam `400 Bad Request` (dados inválidos) ou `404 Not Found` (tarefa inexistente).

## Exemplo de requisição

```json
{
  "name": "Estudar C#",
  "description": "Revisar controllers e use cases",
  "priority": "high",
  "dueDate": "2026-12-01",
  "status": "pending"
}
```

## Regras de validação

- **Nome:** obrigatório, máximo de 100 caracteres
- **Descrição:** opcional, máximo de 500 caracteres
- **Data limite:** não pode estar no passado na criação
- **Prioridade:** `low`, `medium` ou `high`
- **Status:** `pending`, `inProgress` ou `completed`

## Como executar

```bash
git clone https://github.com/SEU-USUARIO/NOME-DO-REPO.git
cd NOME-DO-REPO
dotnet run --project TaskManager.API
```

Depois, acesse o Swagger em `https://localhost:<porta>/swagger`.

> Os dados são armazenados em memória e são perdidos quando a aplicação é encerrada.
