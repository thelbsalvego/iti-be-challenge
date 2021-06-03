# iti-be-challenge

## Como executar

- Esté projeto utiliza .NET Core 5.0. Caso você não o tenha, pode conseguir [aqui](https://dotnet.microsoft.com/download/dotnet/5.0)

- Clone este repo

- No diretório do repo, execute os comandos
```
dotnet build ./src/BackEndChallenge/BackEndChalllenge.csproj
dotnet run ./src/BackEndChallenge/BackEndChalllenge.csproj
```

- Você poderá realizar chamadas para o endpoint 
```
http://localhost:5000/api/password/digiteasenhadesejada
```

## Como executar os testes
## Tecnologias

As seguintes tecnologias foram utilizadas nesse projeto

-   [.NET Core](https://dotnet.microsoft.com/)

## Arquitetura

*Premissa*
Dado que o desafio nos propõe a criação de uma API especializada em aplicar regras de validação de senha em uma string informada, tomamos a decisão de que estaremos construindo uma aplicação especializada no contexto "Password".

### Camada de API
Decidiu-se utilizar o **ASP.NET Core Web Api** por conta dos templates, scaffolding e configurações que o framework oferece *out-of-box*, acelerando o processo de criação do projeto.

Nesta camada, encontra-se o Controller "Password", seguindo os padrões de MVC e REST, este é nosso recurso e nosso domínio.

### Camada de Domínio 