# Back-end challenge

Seja bem-vindo ao repositório do projeto Bookstore, um caso de uso que deve ser implementado contendo uma versão para plataforma web. Obrigado por participar do desafio da Dr.Cash! Estamos muito contentes pelo seu primeiro passo para fazer parte de um time excepcional.

## Afinal, o que é esse desafio?

Primeiramente é importante se atentar aos pilares da Dr.Cash, seguindo metodologias de desenvolvimento ágil.

- [Transparência] - Todo momento é momento para perguntar, tirar dúvidas e conversar sobre os processos e tarefas a serem executados, comunicação em primeiro lugar, sempre.

- [Adaptabilidade] - Ofereça melhorias baseado em perspectivas e fundamentos, como também se adeque as normas impostas visando padrões já estipulados.

- [Autonomia] - Ser autodidata, proativo e fidelidade na busca constante por conhecimento.

## Desafio
Gabriel é o dono de uma livraria e precisa de um software para fazer o controle do seu estoque de livros. Foi contratada uma empresa para implementar esse sistema e você é o desenvolvedor responsável pela implementação do back-end. 

Deve ser criado uma Web API RESTful em Asp.NET Core, onde devem conter as rotas responsáveis pelo CRUD de livros. Essa api deve estar conectada a uma instância de banco de dados Microsoft SQL Server utilizando Entity Framework.

Um livro possui: 
*	Título
*	Autor
*	Gênero
*	Quantidade de cópias

Gabriel tem que ser capaz de adicionar novos gêneros e autores para usar no cadastro de livros. 

### Documentação da API
**https://localhost:5001/swagger/index.html**

### Obs.: Para criação de usuário é necessário informar as Funções do usuário.
**Funções Disponíveis**
1. Admin
2. Employee
3. User

**Ex:**
```Json
{
  "email": "gabriel@gmail.com",
  "password": "#StrongPassword2021",
  "firstName": "Gabriel",
  "lastName": "António",
  "phoneNumber": "+244945869594",
  "roles": [
    "Admin"
  ]
}
```

### Obs.: instância do SQL Server deve estar conectado ao localhost

## Frameworks aplicadas no projeto


**Atenção** - Informe quais recursos de terceriros foram utilizados no projeto e descreva o por quê.
**Frameworks Usadas**

**Microsoft.AspNetCore.Identity.EntityFrameworkCore:** é uma estrutura de Mapeamento Objeto Relacional (ORM), e fornece os desenvolvedores .Net um mecanismo 
automatizado para o armazenamento de dados em banco de dados.

**Microsoft.EntityFrameworkCore.SqlServer:** é um provedor de banco de dados Microsoft SQL Server para Entity Framework Core.

**AutoMapper.Extensions.Microsoft.DependencyInjection:** é uma biblioteca que fornece um mecanismo de mapeamento de um objeto para outro sem ter que percorrer cada propriedade em um objecto para fazer o mapeamento manualmente. 

**Microsoft.AspNetCore.Authentication.JwtBearer:** é um middleware ASP.NET Core que permite que um aplicativo receba um token de portador OpenID Connect, neste projecto usei pra criação do processo de autenticação na Api.

**Microsoft.AspNetCore.Mvc.NewtonsoftJson:** é uma biblioteca que fornece recursos do ASP.NET Core MVC que usam Newtonsoft.Json, neste projecto usei para fazer a serialização e desserialização de objectos em formato JSON.

**Swashbuckle.AspNetCore:** Usada para documentação da API, é uma ferramentas Swagger para documentar APIs construídas no ASP.NET Core.
**https://localhost:5001/swagger/index.html**

**X.PagedList.Mvc.Core:** é biblioteca para fácil paginação por qualquer IEnumerable/IQueryable no ASP.NET Core, neste caso usei para permitir a paginação das requisições feitas na API.



## Experiência com o projeto 
    # Trabalhar neste projecto foi muito bom pois me porpocionou a ouportunidade de ir a busca de mais informações para implementação de uma boa arquitetura no projecto, tive a oportunidade de aplicar os conceitos de Repositório e padrão de unidade (Unit of Work), este padrão de desenvolvimento facilitou muito o meu processo de realização de CRUD nas tabelas que envolvem o sistema.
    

## Futuro

Pretendo continuar a desenvolver este projecto e deixá-lo mais sério de modo a que possa tornar-se um projecto padrão e de referência para qualquer Livraria.

**Planos de Melhoria**
1. Pretendo adicionar mais informações nas tabelas de modo que tenha-se dados mais precisos;
2. Implementar a área de autenticação e gerenciamento de usuários de modo que o senhor Gabriel possa espandir o seu negócio e poder adicionar os seus funcionários para ajudarem no processo de venda de livros (**obs:** este ponto já encontra-se em desenvolvimento);
3. Adicionar restrições de acesso  as rotas da API e atribuição de permissões para usuário da plataforma (**https://github.com/derciosinione/back-end-challenge/tree/feat/AuthPrivatedRoutes**);
4. Adicionar um sistema de venda de livros e gerenciamento de stock (**obs:** este ponto já encontra-se em desenvolvimento);
5. Implementar a Área de Relatório de vendas e livros mais adquiridos;
6. Adicionar a possibilidade de um usário entrar na plataforma e comprar um lívro;

**ATENÇÃO**

Depois de implementar a solução, envie um pull request para este repositório pela interface do Github.

O nome da branch deve seguir o seguinte padrão: **nome-sobrenome**.

O processo de Pull Request funciona da seguinte maneira:
1. Faça um fork deste repositório (não clonar direto!);
2. Faça seu projeto neste fork;
3. Commit e suba as alterações para o SEU fork;
4. Pela interface do Github, envie um Pull Request.
5. Deixe o fork público para facilitar a inspeção do código.


Obs.: Não tente fazer o PUSH diretamente para ESTE repositório!

**A data limite para entrega desse desafio é: 29/08/2021**
