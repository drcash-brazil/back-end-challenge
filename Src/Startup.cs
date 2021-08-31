using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BibliotecaDrCash.Filters;
using BibliotecaDrCash.Models;
using BibliotecaDrCash.Repository;
using BibliotecaDrCash.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace BibliotecaDrCash
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string dbconnection = Configuration.GetConnectionString("SqlserverConnection");

            services.AddDbContextPool<AppDbContext>(op => op.UseSqlServer(dbconnection,options => options.EnableRetryOnFailure()));
            
             // Inject repositories
            services.AddScoped<IRepository<Autor>,AutorRepository>();
            services.AddScoped<IRepository<Genero>,GeneroRepository>();
            services.AddScoped<IRepository<Livro>,LivroRepository>();
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();

            //Inject services
            services.AddScoped<IService<Autor>,AutorService>();
            services.AddScoped<IService<Genero>,GeneroService>();
            services.AddScoped<ILivroService, LivroService>();

             // Inject validators
            services.AddScoped<ValidationFilterAttribute>();
            services.AddScoped<ValidationEntityExistAttribute<Autor>>();
            services.AddScoped<ValidationEntityExistAttribute<Genero>>();
            services.AddScoped<ValidationEntityExistAttribute<Livro>>();
            
            services.AddControllers();
            
        
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "aspnet5", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "aspnet5 v1"));
            }
            else
            {
                app.UseExceptionHandler("/errors");
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
