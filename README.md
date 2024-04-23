## LearnNET API 🌐

## ⚙️ Status: Construção.

### Este projeto é uma API Web que implementa um sistema de Plataforma de Ensino.


### Funcionalidades 🖥️ 

- CRUD Assinatura
- CRUD Curso
- CRUD Modulo
- CRUD Aula
- CRUD Usuario (Conectar Usuario com Assinatura).
  

### Regras do Negócio  📏

I:
- Concluir Aula com Nota (UsuarioAulaConcluida)
- Status de Curso para Usuário: Quando carregar o curso para um usuário, puxar tempo total, tempo restante, porcentagem

II:
- Se inscrever em uma assinatura (Asaas)
- Se integrar com Asaas, passando os dados do Cliente e criando o Cliente lá
- Criar Cobrança no Asaas com o Id do Cliente
- Obter o Id da cobrança e salvar em PagamentoAssinatura
- Criar um webhook para receber notificações das cobranças

III:
- Aprender sobre Hotmart e Webhooks


### Tecnologias que serão utilizadas 💡


- ASP.NET Core 8: framework web para desenvolvimento de aplicações .NET
- Entity Framework Core: persistência e consulta de dados.
- SQL Server: banco de dados relacional.
- Microsserviços.
- Mensageria com RabbitMQ.
- API Gateway Asaas.
  

### Padrões, conceitos e arquitetura que serão utilizados 📂


- Fluent Validation
-  Padrão Repository
-  Middleware (Lidar com exceções)
-  InputModel, ViewModel
-  DTO’s 
-  IEntityTipeConfiguration 
-  Sql Server 
-  Unit Of Work
-  HostedService
-  Domain Event
-  CQRS
-  Teste Unitários
-  Arquitetura Limpa
-  Microsserviços
-  RabbitMQ


 
## Instalação

### Requisitos

Antes de começar, verifique se você tem os seguintes requisitos instalados:

- [.NET SDK 8.0](https://dotnet.microsoft.com/download/dotnet/8.0): A versão do .NET Framework necessária para executar a API.
- [SQL Server](https://www.microsoft.com/en-us/sql-server): O banco de dados utilizado para armazenar os dados.

### Clone

Clone o repositório do GitHub:

```bash
git clone https://github.com/[seu-usuário]/LearnNET.API.git
```

### Navegue até a pasta do projeto:

```bash
cd LearnNET.API
```

### Abra o projeto na sua IDE de preferência (a IDE utilizada para desenvolvimento foi o Visual Studio)

### Restaure os pacotes:

```bash
dotnet restore
```

### Configure o banco de dados:

1. Abra o arquivo `appsettings.json`.
2. Altere as configurações do banco de dados para corresponder ao seu ambiente.
3. Faça as devidas alterações para as funcionalidades: Gateway Asaas.

### Execute a API:

Para executar a API, use o seguinte comando:

```bash
dotnet run
```

### Lembre-se de substituir [seu-usuário] pelo seu nome de usuário do GitHub.
### Lembre-se de fazer as devidas alterações para o uso correto das API de Gateway Asaas.

Este projeto foi criado para fins didáticos e não abrange todas as regras e conceitos necessários de uma aplicação real em produção.*
