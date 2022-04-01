# Back-end challenge

Seja bem-vindo ao repositório do projeto Bookstore, um caso de uso que deve ser implementado contendo uma versão para plataforma web. Obrigado por participar do desafio da Dr.Cash! Estamos muito contentes pelo seu primeiro passo para fazer parte de um time excepcional.

# Para Startar o projecto

A aplicação foi desenvolvida com dotnet na versão 6.

Criei um shell que facilitaria rodar a aplicação uma vez que foi trabalhado em camadas, para não ter que percorrer entre as pastas,
a outra coisa eu usei uma instância local para conexão porêm a partir da imagem que gerei no Docker na minha maquina.

Para alteração basta entrar em `BookStore.Domain.Api - appSettings.json e appSettings.Development.json` e alterar a connectionString para
**Server=localhos\\SQLEXPRESS,1433;Database=BookStore;User ID=sa;Password=''** e a aplicação funciona lindamente

O scripts a ser gerados

Criar antes a base de dados `BookStore`

Para executar as migrações na base de dados

```bash
bash migration.sh
```

Para rodar a aplicação

```bash
bash script.sh
```

Payload para criação do book

```json
{
  "title": "Hard book 12",
  "authorId": "f95b1713-4c2c-439d-9657-8ad669c7bf83",
  "genreId": "ec2a83a5-6846-4075-bc5e-c631f5c6698d",
  "numberOfCopies": 20
}
```

Payload para actualização do book

```json
{
  "id": "e3034aed-0bb4-45e3-9b91-fbc23af67c99",
  "title": "Hard book 12",
  "authorId": "f95b1713-4c2c-439d-9657-8ad669c7bf83",
  "genreId": "ec2a83a5-6846-4075-bc5e-c631f5c6698d",
  "numberOfCopies": 20
}
```

## Afinal, o que é esse desafio?

Primeiramente é importante se atentar aos pilares da Dr.Cash, seguindo metodologias de desenvolvimento ágil.

- [Transparência] - Todo momento é momento para perguntar, tirar dúvidas e conversar sobre os processos e tarefas a serem executados, comunicação em primeiro lugar, sempre.

- [Adaptabilidade] - Ofereça melhorias baseado em perspectivas e fundamentos, como também se adeque as normas impostas visando padrões já estipulados.

- [Autonomia] - Ser autodidata, proativo e fidelidade na busca constante por conhecimento.

## Desafio

Gabriel é o dono de uma livraria e precisa de um software para fazer o controle do seu estoque de livros. Foi contratada uma empresa para implementar esse sistema e você é o desenvolvedor responsável pela implementação do back-end.

Deve ser criado uma Web API RESTful em Asp.NET Core, onde devem conter as rotas responsáveis pelo CRUD de livros. Essa api deve estar conectada a uma instância de banco de dados Microsoft SQL Server utilizando Entity Framework.

Um livro possui:

- Título
- Autor
- Gênero
- Quantidade de cópias

Gabriel tem que ser capaz de adicionar novos gêneros e autores para usar no cadastro de livros.

### Obs.: instância do SQL Server deve estar conectado ao localhost

## Frameworks aplicadas no projeto

Os framewors que foram utilizados no projecto são;

- Microsoft.EntityFrameworkCore.Design
- Microsoft.EntityFrameworkCore.InMemory
- Microsoft.EntityFrameworkCore.Relational
- Microsoft.EntityFrameworkCore.SqlServer
- Microsoft.EntityFrameworkCore.Tools

## Experiência com o projeto

Com este projecto consegui desenvolver mais os meus conhecimento na linguagem c# e no framework asp.net.core,
pensando na arquitetura de software, nas tuas relações etc.

E a simplicidade da mesma aplicação agredou valor no acto de desenvolvimento da mesma.
Foi desenvolvido com bastante entrega, de modo a ter como resultado não apenas um projecto mas
um projecto com qualidade por ser o foco.

## Futuro

Futura mente acredito que podemos adicionar um modelo de negócio a mesma aplicação de modo a fazer com que ela seja a base para
várias provedoras de livros, adicionar talvez algumas funcionalidades que complementariam esse recurso e fechar a mesma.

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
