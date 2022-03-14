using System;
using DrcashTest.IRepository;
using DrcashTest.Models;
using DrcashTest.Repositories;
using DrcashTest.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace DrcashTest {
    public class Startup {
        public Startup (IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices (IServiceCollection services) {
            

            services.AddDbContext<DataContext> (opt => opt.UseSqlServer (
                Configuration.GetConnectionString ("default")));

            services.AddAuthentication ();
            services.ConfigureIdentity ();
            services.ConfigureJWT (Configuration);

           

            services.AddCors (o => {
                o.AddPolicy ("AllowAll", builder => builder.AllowAnyMethod ().AllowAnyHeader ());
            });

            services.AddSwaggerGen (Options => {
                Options.SwaggerDoc ("v1",
                    new Microsoft.OpenApi.Models.OpenApiInfo {
                        Title = "Drcash API",
                            Description = "Teste da Drcash Desenvolvido Por Adnderson Francisco",
                            Version = "v1"
                    });
            });

            services.AddAutoMapper (AppDomain.CurrentDomain.GetAssemblies ());

            services.AddScoped<IAuthManager, AuthManager> ();
            services.AddScoped<IAuthorsRepository, AuthorsRepository> ();
            services.AddScoped<ICategoryRepository, CategoryRepository> ();
            services.AddScoped<IBookRepository, BookRepository> ();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure (IApplicationBuilder app, IHostingEnvironment env) {
            app.UseCors ("AllowAll");

            if (env.IsDevelopment ()) {
                app.UseDeveloperExceptionPage ();
            } else {
                app.UseHsts ();
            }
            app.ConfigureExceptionHandler ();
            app.UseHttpsRedirection ();
            app.UseMvc ();

           
            app.UseAuthentication ();
            app.UseAuthorization ();

            app.UseEndpoints (endpoints => {
                endpoints.MapControllers ();
            });

            app.UseSwagger ();
            app.UseSwaggerUI (Options => {
                Options.SwaggerEndpoint ("/swagger/v1/swagger.json", "Drcash API");
                Options.RoutePrefix = "";
            });
        }
    }
}