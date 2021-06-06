# iti-be-challenge

## Como executar

- Este projeto utiliza .NET Core 5.0. Caso você não o tenha, pode conseguir [aqui](https://dotnet.microsoft.com/download/dotnet/5.0)

- Clone este repo

- No diretório do repo, execute os comandos
```
dotnet build ./src/BackEndChallenge/BackEndChallenge.csproj
dotnet run -p ./src/BackEndChallenge/BackEndChallenge.csproj
```

- Você poderá realizar chamadas para o endpoint 
```
http://localhost:5000/api/password/digiteasenhadesejada
```
**Por favor, não esqueça de *encodar* os caracteres especiais na URI!**

## Como executar os testes

- No diretório do repo, execute o comando
```
dotnet test ./test/BackEndChallenge/BackEndChallenge.Test.csproj
```

## Tecnologias

As seguintes tecnologias foram utilizadas nesse projeto

-   [.NET Core](https://dotnet.microsoft.com/)

## Arquitetura

*Premissa*: Dado que o desafio nos propõe a criação de uma API especializada em aplicar regras de validação de senha em uma string informada, estaremos construindo uma aplicação especializada no contexto "Password".

A aplicação terá 3 camadas (da mais externa para a mais interna):

| Ordem |    Camada    |
|-------|--------------|
| 1     | Apresentação |
| 2     | Use-Cases    |
| 3     | Domínio      |

### Camada de Apresentação
Decidiu-se utilizar o **ASP.NET Core Web Api** por conta dos templates, scaffolding e configurações que o framework oferece *out-of-box*, acelerando o processo de criação do projeto.

Nesta camada, encontra-se o Controller "Password", seguindo os padrões de MVC e REST, este é nosso recurso e nosso domínio.

O endpoint está utilizando o verbo GET, por se tratar de uma consulta potencialmente idempotente.
Essa **premissa** da idempotência implica que as regras de senhas válidas não mudam com frequência, e então, a requisição pode ser *cacheada* - por isso o GET.
Entretanto, como forma de mostrar que existem outros meios de tratar esse assunto, o endpoint está retornando o cabeçalho de no-cache - apenas como um exemplo de como retirar a qualidade de *cacheabilidade* deste endpoint.

### Camada de Use-Case
Apesar do tamanho diminuto da solução, está camada de indireção foi incluída apenas para desacoplar a Camada de Apresentação da Camada de Domínio.

Desta forma, os *use-cases* contém a lógica para obter os *aggregate-roots* (seja através de *repositórios*, *serviços* ou qualquer outro padrão).

Temos apenas um caso de uso: *ValidatePassword*.

### Camada de Domínio 
Nesta camada, seguindo os conceitos de DDD, temos o *model* (e *aggregate root*) Password, que representa um senha sendo enviada para processamento.

O próprio modelo de domínio responderá se a senha é válida ou não. Este é um atributo do mesmo e uma função dele. Desta forma, não o domínio não fica "anêmico".

O *serviço de domínio* de validação é injetado dentro do modelo de domínio. Esta inversão de controle permitirá extensibilidade do domínio no quesito de regras de validação. 