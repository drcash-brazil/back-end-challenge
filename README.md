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

- Microsoft.EntityFrameworkCore: EF Core pode servir como um mapeado relacional de objeto (O/RM), que: Permite que os desenvolvedores do . NET trabalhem com um banco de dados usando objetos . NET.
- Microsoft.EntityFramworkCore.SqlServer: Utilizado para realização da comunicação com o banco de dados SQL Server por meio de migrações.


## Experiência com o projeto 
	O desafio proporcionou uma interessante experiência com NET.Core até mesmo por ser meu segundo contato com o framework. A ideia de incluir mais de um autor e genero por livro, como por exemplo
	o livro Ozob V.1 - Protocolo Molotov que possui autor e co-autor, bem como outros livros que são classificados por mais de um tipo de genero, torna o relacionamento entre as classes um ponto de 
	atenção fundamental em entender com maior precisão a demanda de um software.

## Futuro
	Apesar de ser apenas um desafio, o software que visa realizar a gestão de controle de livros de uma biblioteca pode ter grande potencial. Informações como "idioma", "região", "disponibilidade", "Data de Publicação"
	entre outras tornariam o controle dos livros ainda mais informativo ao responsável pela gestão da biblioteca. Funcionalidades como de compra e venda, ou aluguel dos livros pode tornar a experiencia com a nova ferramenta ainda mais 
	satisfatória ao cliente.

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
