using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Identity.Web;
using Microsoft.Net.Http.Headers;
using Microsoft.OpenApi.Models;

namespace Hangfire.IO.Extensions
{
    public static class BuilderExtensions
    {
        public static WebApplicationBuilder AddArchitectures(this WebApplicationBuilder builder)
        {
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();

            builder.Services
                .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddMicrosoftIdentityWebApi(builder.Configuration.GetSection("AzureAd"));

            builder.Services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo() { Title = "Web Jobs Apis", Version = "v1" });
                options.AddSecurityDefinition("oAuth2", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
                {
                    Flows = new Microsoft.OpenApi.Models.OpenApiOAuthFlows
                    {
                        ClientCredentials = new OpenApiOAuthFlow
                        {
                            //TokenUrl = new Uri("https://newbloomerswebjobsapi-c6ezf4arbxcghtgg.eastus2-01.azurewebsites.net/api/Auth/token")
                            TokenUrl = new Uri("https://localhost:7113/api/Auth/token")
                        }
                    },
                    In = ParameterLocation.Header,
                    Name = HeaderNames.Authorization,
                    Type = SecuritySchemeType.OAuth2
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme, Id = "oAuth2"
                            }
                        },
                        new string[] { "Api" }
                    }
                });
            });

            builder.Services.AddCors();

            return builder;
        }
    }
}