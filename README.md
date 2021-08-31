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

### Obs.: instância do SQL Server deve estar conectado ao localhost

## Frameworks aplicadas no projeto


**Atenção** - Informe quais recursos de terceriros foram utilizados no projeto e descreva o por quê.

*   Microsoft.EntityFrameworkCore (5.0.9)
        Para criação e utilização do banco de dados utilizando a abordagem code first e manipulação utilizando as rotinas de consultas do C#
*   Microsoft.EntityFrameworkCore.SqlServer (5.0.9)
        Database provider do SQL Server para o EntityFramework
*   Microsoft.EntityFrameworkCore.Tools (5.0.9)
        Ferramentas do EntityFramework para possibilitar o uso de comandos para gerenciamento das migrations e do banco de dados
*   Swashbuckle.AspNetCore (5.6.3)
        Ferramenta para documentação da API

## Experiência com o projeto 
    Como estou familiarizado com as tecnologias do mundo .NET na parte técnica o desenvolvimento fluiu naturalmente, entretanto
    com algumas pesquisas encontrei meios diferentes de pensar e organizar o projeto dos quais tinha utilizado em projetos anteriores
    trazendo assim uma experiência nova e divertida durante o desenvolvimento.

## Futuro

    1. Armazenar o ISBN do livro, evitando assim ambiguidades durante a identificação.
    2. Implementar sistema de autenticação e restrições de acesso as rotas da API.
    3. Armazenar mais informações à respeito dos livros como data de publicação, editora, idioma, etc.
    4. Implementar sistema de geração de relatório do estoque.
    5. Implementar serviço de realização periódica de backup do banco de dados.


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
