using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BackEnd.DbConfig;
using BackEnd.Helper;
using BackEnd.Interface;
using BackEnd.Models;
using BackEnd.Repositories;
using BackEnd.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BackEnd
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
                                    services.AddCors();
                                    services.AddControllers().AddNewtonsoftJson(options =>options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
                                    services.AddDbContext<BackEndContext>(e => e.UseSqlServer(Configuration["ConnectionStrings:Connection"]));
                                    services.AddTransient<IRepositoryBase<Movement>, RepositoryBase<Movement>>();
                                    services.AddTransient<IBookRepository, BookRepository>();
                                    services.AddTransient<IAuthorRepository, AuthorRepository>();
                                    services.AddTransient<IGenreRepository, GenreRepository>();
                                    services.AddTransient<IOrderBookRepository, OrderBookRepository>();
                                    services.AddTransient<IUserRepository, UserRepository>();
                                    services.AddTransient<IMovementRepository, MovementRepository>();
                                    services.AddTransient<ITokenService, TokenService>();
                                    services.AddSwaggerGen(c =>
                                    {
                                                c.SwaggerDoc("v1", new OpenApiInfo { Title = "BackEnd", Version = "v1" });
                                                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                                                {
                                                            In = ParameterLocation.Header,
                                                            Description = "Bearer <TOKEN>",
                                                            Name = "Authorization",
                                                            Type = SecuritySchemeType.ApiKey
                                                });
                                                c.AddSecurityRequirement(new OpenApiSecurityRequirement{
                                                            {
 new OpenApiSecurityScheme{
                                                                Reference=new OpenApiReference
                                                                {
                                                                   Type=ReferenceType.SecurityScheme,
                                                                   Id="Bearer"
                                                                }
                                                            },
                                                            new string[]{}
                                                            }


                                                });
                                    });
                                    services.AddAuthentication(x =>
                                    {
                                                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                                                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                                    })
                                            .AddJwtBearer(x =>
                                            {
                                                        x.RequireHttpsMetadata = false;
                                                        x.SaveToken = true;
                                                        x.TokenValidationParameters = new TokenValidationParameters
                                                        {
                                                                    ValidateIssuerSigningKey = true,
                                                                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(Configuration["Secret"])),
                                                                    ValidateIssuer = false,
                                                                    ValidateAudience = false
                                                        };
                                            });


                        }

                        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
                        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
                        {
                                    if (env.IsDevelopment())
                                    {
                                                app.UseDeveloperExceptionPage();
                                                app.UseSwagger();
                                                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "BackEnd v1"));
                                    }

                                    app.UseHttpsRedirection();

                                    app.UseRouting();
                                    app.UseCors(builder => builder.AllowAnyOrigin()
                                                                  .AllowAnyMethod()
                                                                  .AllowAnyHeader());
                                    app.UseAuthentication();
                                    app.UseAuthorization();

                                    app.UseEndpoints(endpoints =>
                                    {
                                                endpoints.MapControllers();
                                    });
                        }
            }
}
