using System;
using DrcashTest;
using DrcashTest.IRepository;
using DrcashTest.Models;
using DrcashTest.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace back_end_challenge
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services
                .AddDbContext<DataContext>(opt =>
                    opt
                        .UseSqlServer(Configuration
                            .GetConnectionString("default")));

            services.AddAuthentication();
            services.ConfigureIdentity();
            services.ConfigureJwt (Configuration);

            services
                .AddControllers()
                .AddNewtonsoftJson(opt =>
                    opt.SerializerSettings.ReferenceLoopHandling =
                        Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services
                .AddCors(o =>
                {
                    o
                        .AddPolicy("AllowAll",
                        builder => builder.AllowAnyMethod().AllowAnyHeader());
                });

            services
                .AddSwaggerGen(c =>
                {
                    c
                        .SwaggerDoc("v1",
                        new OpenApiInfo {
                            Title = "Dr. Cash Backend Challenge",
                            Version = "v1"
                        });
                });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddScoped<IAuthManager, AuthManager>();
            services.AddScoped<IAuthorsRepository, AuthorsRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<IBookRepository, BookRepository>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app
                    .UseSwaggerUI(c =>
                        c
                            .SwaggerEndpoint("/swagger/v1/swagger.json",
                            "back_end_challenge v1"));
            }

            app.UseCors("AllowAll");

            app.ConfigureExceptionHandler();

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app
                .UseEndpoints(endpoints =>
                {
                    endpoints.MapControllers();
                });
        }
    }
}
