# TesteBitzen

## Introdução
Neste teste técnico foi proposto pelo avaliador que fosse criado uma API web contendo as funcionalidades de uma locadora de veículos;

As funcionalidades exigidas na proposta do teste eram:

1. Ser possível cadastrar novos veículos e classificá-los por categoria, montadora e tipo de combustível.
2. Ser possível cadastrar novas categorias de veículos e relacionar os valores de diária com a categoria do veículo.
3. Ser possível cadastrar Usuário/Cliente na aplicação.
4. Ser possível gerenciar as locações dos veículos.

### Tecnologias utilizadas:
- .NET 7
- Entity Framework Core
- PostgreSQL
- PgAdmin
- Docker
- Swagger
- Visual Studio 2022

### Abordagem
A abordagem que tive para solucionar o problema foi inicialmente compreender o contexto o qual eu estava inserido, eu tinha um sistema de locadora de veículos e ele já possuia algumas regras que necessitavam que fossem seguidas, portanto eu comecei desenvolvendo e criando todas as entidades da aplicação com o Entity Framework, criando as models que são as representações das minhas entidades que são também das minhas colunas no banco de dados.

Após feitas as entidades eu parti para a criação das representações dos métodos e interfaces de cada entidade (vide diretório *Repositories*) e quais os respectivos comportamentos de cada entidade dado o contexto da ementa do teste.

Em seguida, mapeei todas os campos das minhas entidades (vide diretório *Data/Map*) para que estivessem um escopo controlado como, manipulando os campos que possuiam chaves primárias e chaves estrangeiras, quais campos eram obrigatórios, quais tinham limite de caracteres e assim por diante.  

Então parti para os controllers da minha api (vide pasta *Controllers*) onde desenvoli toda a lógica, verbos HTTP, validações e regras de negócio da aplicação. 

---

A aplicação conta com 2 containers Docker com as imagens do banco de dados PostgreSQL e do painel PgAdmin para manipulação e visualização das tabelas do nosso banco de dados.

É necessário que sejam instaladas as dependências pela CLI ou via NuGet Package Manager na IDE do Visual Studio 2022. 

Dependências:
- Microsoft.EntityFrameworkCore - v7.0.4^
- Microsoft.EntityFrameworkCore.Design - v7.0.4^
- Microsoft.EntityFrameworkCore.Tools - v7.0.3^
- Npgsql.EntityFrameworkCore.PostgreSQL - v7.0.3^
- Swashbuckle.AspNetCore - v6.5.0^
- Newtonsoft.Json - v13.0.3^

Foi gerado também 2 containers Docker com as imagens do banco de dados PostgreSQL e do painel PgAdmin para manipulação e visualização das tabelas (vide [docker-compose.yml]("docker-compose.yml")).


# Uso
Após feitas as instalações das dependências, inicialize os containers Docker via CLI `docker compose up` ou via Docker Desktop para que sejam instânciadas as imagens dos containers que são importantes para o funcionamento do projeto, caso tudo ocorra bem ao inicializar, em seus navegador será possível acessar o painel pgAdmin pela URL `localhost:5050` em seu navegador.

No visual studio talvez seja necessário criar as migrações do banco de dados via Package Manage Console, basta utilizar 2 comandos, `Add-Migration <NomeDaMigration>` nesta etapa, altere  `<NomeDaMigration>` para um nome signifativo para a migração;

Em seguida rode o segundo comando que é `Update-Database`, esse comando será suficiente para a subir a migração para o banco de dados oficial que você criou no passo anterior.

Feito estes 2 passos, você pode agora iniciar a aplicação via CLI com `dotnet build` e `dotnet run` ou pelo visual studio clicando no botão verde chamado play logo ao topo da IDE.

Neste momento é esperado que abra uma nova aba em seu navegador já com a aplicação rodando e com toda a documentação do swagger pronta para ser testada.

## Melhorias futuras
Serão feitos alguns pequenos ajustes e bugfix na hora de enviar uma requisição via swagger que estão disfuncionais.