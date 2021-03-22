using DrCashChallenge.Business.Interfaces.Services;
using DrCashChallenge.Business.Interfaces.Repositories;
using DrCashChallenge.Business.Notifications;
using DrCashChallenge.Business.Services;
using DrCashChallenge.Data.Context;
using DrCashChallenge.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;

namespace DrCashChallenge.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DrCashChallengeContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IAuthorRepository, AuthorRepository>();
            services.AddScoped<IGenreRepository, GenreRepository>();

            services.AddScoped<INotificator, Notificator>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthorService, AuthorService>();
            services.AddScoped<IGenreService, GenreService>();

            return services;
        }
    }
}
