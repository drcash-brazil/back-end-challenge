cd BookStore.Domain.Infra
# dotnet ef migrations add InicialCreate --startup-project ../BookStore.Domain.Api
dotnet ef database update --startup-project ../BookStore.Domain.Api/

cd ..