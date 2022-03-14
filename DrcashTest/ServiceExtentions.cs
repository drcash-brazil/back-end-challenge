using System.Text;
using System;
using DrcashTest.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace DrcashTest.IRepository
{
  public static class ServiceExtentions
  {
    public static void ConfigureIdentity(this IServiceCollection services)
    {
      var builder = services.AddIdentityCore<Users>(q => q.User.RequireUniqueEmail = true);

      builder = new IdentityBuilder(builder.UserType, typeof(IdentityRole), services);
      builder.AddEntityFrameworkStores<DataContext>().AddDefaultTokenProviders();
    }

    //GLOBAL ERROR HANDLER
    public static void ConfigureExceptionHandler(this IApplicationBuilder app)
    {
      app.UseExceptionHandler(error =>
      {
        error.Run(async context =>
        {
          context.Response.StatusCode = StatusCodes.Status500InternalServerError;
          context.Response.ContentType = "application/json";
          var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
          if (contextFeature != null)
          {
            await context.Response.WriteAsync(new Error
            {
              StatusCode = context.Response.StatusCode,
              Message = "Ocorreu um erro interno no servidor. Por favor tente novamente mais tarde.",
            }.ToString());
          }


        });
      });
    }

    public static void ConfigureJWT(this IServiceCollection services, IConfiguration Configuration)
    {
      var jwtSettings = Configuration.GetSection("Jwt");
      var key = jwtSettings.GetSection("Secret").Value;

      services.AddAuthentication(o =>
      {
        o.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
        o.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
      }).AddJwtBearer(o =>
      {
        o.TokenValidationParameters = new TokenValidationParameters
        {
          ValidateIssuer = true,
          ValidateLifetime = true,
          ValidateAudience = false,
          ValidateIssuerSigningKey = true,
          ValidIssuer = jwtSettings.GetSection("Issuer").Value,
          IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key)),
        };
      });
    }
  }
}