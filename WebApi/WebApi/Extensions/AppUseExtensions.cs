using Microsoft.Net.Http.Headers;

namespace WebApi.Extensions
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app)
        {
            if (!System.Diagnostics.Debugger.IsAttached)
            {
                app.UseCors(policy =>
                policy.WithOrigins("http://172.25.1.4:7575", "http://localhost:7575", "https://webapplication.newbloomers.com.br:7475")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithHeaders(HeaderNames.ContentType)
                );
            }

            else
            {
                app.UseCors(policy =>
                policy.WithOrigins("https://localhost:7083", "https://localhost:7049")
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .WithHeaders(HeaderNames.ContentType)
                );
            }

            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();

            return app;
        }
    }
}
