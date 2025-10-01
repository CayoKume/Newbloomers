using Application.Core.Middlewares;

namespace Hangfire.IO.Extensions
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, string? serverName)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
            app.UseSwagger(c => { c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0; });
            app.UseSwaggerUI(c =>
            {
                c.OAuthClientId("e2528c48-69b9-42ff-859d-406b4acfeeea");
                c.OAuthClientSecret("jdS8Q~v7imbh1eFvibYIHpJgrh6PsUF1RA6Fobwi");
            });
            app.UseHttpsRedirection();
            app.UseAuthorization();

            //app.UseHangfireDashboard();
            //LinxMicrovixERPRecurringJobsExtensions.AddRecurringJobs();
            //LinxMicrovixB2CRecurringJobsExtensions.AddRecurringJobs();
            return app;
        }
    }
}
