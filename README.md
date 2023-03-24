# TesteBitzen

### Tecnologias utilizadas:
- .NET 7
- Entity Framework Core
- PostgreSQL
- PgAdmin
- Docker Compose
- Swagger
- Visual Studio 2022

Este repositório contém o código do teste técnico da Bitzen que representa um sistema de locação de veículos.

A base do projeto foi gerada pela CLI do .NET 7 utilizando o comando `dotnet new webapi -o TesteBitzen` onde "TesteBizen" é o nome do projeto. 

É necessário que sejam instaladas as dependências pela CLI ou via NuGet Package Manager na IDE do Visual Studio 2022. 

Foi gerado também 2 containers Docker com as imagens do banco de dados PostgreSQL e do painel PgAdmin para manipulação e visualização das tabelas.

# Descrição de Pastas

- **Controllers**: Nesta pasta estão localizadas os controladores da API, ou seja, onde está representada a lógica dos métodos de todas as entidades da aplicação.

- **Data**: Neste diretório está localizado todo a representação do contexto do banco de dados da aplicação.

- **Data>Map**: 

- Migrations
- Models
- Repositories



