using DrCash.Teste.Application.Interfaces;
using DrCash.Teste.Application.Notificacoes;
using DrCash.Teste.Application.Services;
using DrCash.Teste.Infra.Context;
using DrCash.Teste.Infra.Interfaces;
using DrCash.Teste.Infra.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace DrCash.Teste.Api.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<MeuDbContext>();
            services.AddScoped<ILivroRepository, LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
           
            services.AddScoped<INotificador, Notificador>();
            services.AddScoped<ILivroService, LivroService>();
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IGeneroService, GeneroService>();

            return services;
        }
    }
}
