# 📝 API de Gerenciamento de Tarefas (To-Do List)

API RESTful desenvolvida com ASP.NET Core 8, utilizando Entity Framework Core 8 e SQL Server via Docker. Permite **criar**, **listar**, **atualizar** e **remover** tarefas de forma simples e eficiente.

---

## ⚙️ Tecnologias Utilizadas

- **ASP.NET Core 8**
- **Entity Framework Core 8**
- **SQL Server (via Docker)**
- **AutoMapper**
- **Swagger/OpenAPI**
- **Docker Compose**
- **xUnit** (testes)
- **Moq** (mocks para testes)
- **FluentAssertions** (asserts mais legíveis)

---

## 🚀 Como Executar o Projeto

### 1. Clone o Repositório

```bash
git clone git@github.com:NataliGabriel/NTL-Tarefas.git
cd NTL-Tarefas
git checkout feature/api-tarefas
```
---

### 2. Suba o SQL Server com Docker

> Execute o comando abaixo no diretório onde está o `docker-compose.yaml`:

```bash
docker-compose up -d
```

---

### 3. Configure o `appsettings.json` (se necessário)

Edite a **connection string** caso tenha alterado usuário, senha ou porta:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=master;User Id=sa;Password=P@ssw0rd2025!;TrustServerCertificate=True"
}
```

---

### 4. Aplique as Migrações do EF Core

```bash
dotnet ef migrations add ApiTarefasMigration
dotnet ef database update
```

---

### 5. Rode a Aplicação

 ```bash
dotnet run
``` 
---
  
## 🧪 Executando os Testes

### 1. Navegue até o projeto de testes:

```bash
cd NTL-Tarefas.Tests

```
### 2. Execute os testes com:
```bash
dotnet test
```

---
