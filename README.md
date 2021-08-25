## Requisito para rodar o sistema
 **.Net Sdk na versão 5**
 **Servidor SqlServer instalado**
 **Ferramenta EF instalada**(Opcional)
## Passos para execução
  **dotnet build** - **para baixar algumas dependencia em falta na sua maquina.*
  **criar uma base de dados com o nome desafio**
  **comando para instalar a ferramenta EF** -**dotnet tool install --global dotnet-ef* 
  **dotnet ef migrations add InitialMigration** -**caso voce tenha a ferramenta EF então pode correr este comando para ele gerar as migration das sua tabelas.*
  **dotnet ef database update** - **caso voce tenha a ferramenta EF então pode correr este comando para ele gerar as tabela na sua base de dados.*
  **dotnet run**  - **executar o projecto*.
  Depois da execução poderais ter uma visão gerar das API nesta rota:**https://localhost:5001/swagger/index.html**
## Frameworks aplicadas no projeto
 **Microsoft.EntityFrameworkCore**
## Recursos Utilizados
 **Authentication.JwtBearer**  - **utilizamos este recurso para definimos segurança nas API.*
 **EntityFrameworkCore.SqlServer** - **utilizamos este recurso para podemos conectar o nosso projecto com uma base de dados SqlServer* 
 **dotnet ef migrations** - **utilizamos a ferramenta ef para podemos gerar a migration da nossa base de dados* 
## Experiência com o projeto 
 Concernete a este ponto não tenho muito para falar alem de disser que tive uma boa experiência tanto pratica quanto teorica .
## Futuro
 No futoro espero ter que implementar o sistema de compra e venda online dos livro da livraria do Gabriel.
## Obs
 Casa tenha alguma duvida tem um arquivo na pasta do projeto com o nome: **Como utilizar a API**