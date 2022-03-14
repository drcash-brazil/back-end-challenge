using Biblioteca.Data.Context;
using Biblioteca.Data.IRepository;
using Biblioteca.Data.Repository;
using Biblioteca.Service.IService;
using Biblioteca.Service.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Reflection;
using System.IO;
using Microsoft.OpenApi.Models;

namespace Biblioteca
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
            services.AddDbContext<BibliotecaContext>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));

            services.AddControllers();

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "BibliotecaAPI",
                    Description = "API para controle de estoque da biblioteca",                   
                    Contact = new OpenApiContact
                    {
                        Name = "Hálife Alencar",
                        Email = string.Empty,
                        Url = new Uri("https://www.linkedin.com/in/halifealencar/")
                    }
                });
                                
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                
                c.IncludeXmlComments(xmlPath);
            });

            //services
            services.AddScoped<IAutorService, AutorService>();
            services.AddScoped<IGeneroService, GeneroService>();
            services.AddScoped<ILivroService, LivroService>();

            //resitory
            services.AddScoped<IAutorRepository, AutorRepository>();
            services.AddScoped<IGeneroRepository, GeneroRepository>();
            services.AddScoped<ILivroRepository, LivroRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
                        
            //configurando swagger
            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "BibliotecaAPI V1");
                c.RoutePrefix = string.Empty;
            });

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                //endpoints.MapSwagger();
                endpoints.MapControllers();
            });
        }
    }
}
