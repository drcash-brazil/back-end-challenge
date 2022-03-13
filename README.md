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

Documentação da solução desenvolvida para dar resposta ao problema apresentado Pela livraria do Gabriel

### Rota da documentação da API
**https://localhost:5001/index.html**
**http://localhost:5000/index.html**

### Obs.: instância para estabelecer a conexão com o SQL Server deve ser o **localhost**

### Ferramentas utilizadas para o desenvolvimento da solução da livraria do Sr. Gabriel

**Microsoft.AspNetCore.Identity.EntityFrameworkCore:** é uma estrutura de Mapeamento Objeto Relacional (ORM), e fornece os desenvolvedores .Net um mecanismo 
automatizado para o armazenamento de dados em banco de dados.

**Microsoft.EntityFrameworkCore.SqlServer:** é um provedor de banco de dados Microsoft SQL Server para Entity Framework Core.

**Swashbuckle.AspNetCore:** Usada para documentação da API, é uma ferramentas Swagger para documentar APIs construídas no ASP.NET Core.
**https://localhost:5001/index.html**


## Experiência com o projeto 
    #   Desenvolver a solução deste projecto foi uma experiência bastante boa e sobre tudo desafiadora, pois pude evoluir as minhas competências, metodologias e análise para resolução de novos problemas (desafios).
        Foram aplicados alguns conceitos de do  padrão de unidade (Unit of Work), que facilitou na definição e escalabilidade nas regras de negócio na solução desenvolvida.

## Futuro

Pretendo dar sequência no desenvolvimento desta solução  de modo a torna-lo adaptável para diversas livraria.

**Proximos passos**
1. Adicionar novos modolos e funcionalidade do projecto (vendas,registo de stock,registo de clientes,etc);
2. Implementar a área de autenticação e gerenciamento de usuários
3. Adicionar restrições de acesso  as rotas da API de modo a manter a segurança e integridade dos dados; 

**ATENÇÃO**

Depois de implementar a solução, envie um pull request para este repositório pela interface do Github.

O nome da branch deve seguir o seguinte padrão: **nome-sobrenome**.

O processo de Pull Request funciona da seguinte maneira:
1. Faça um fork deste repositório (não clonar direto!);
2. Faça seu projeto neste fork;
3. Commit e suba as alterações para o SEU fork;
4. Pela interface do Github, envie um Pull Request.
5. Deixe o fork público para facilitar a inspeção do código.
