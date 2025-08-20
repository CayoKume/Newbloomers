using Application.Core.Middlewares;

namespace Hangfire.IO.Extensions
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, string? serverName)
        {
            app.UseMiddleware<ExceptionHandlingMiddleware>();
#if DEBUG
            //app.UseSwagger(); //Refatorar Aqui (remover)
            app.UseSwagger(c => { c.OpenApiVersion = Microsoft.OpenApi.OpenApiSpecVersion.OpenApi2_0; });
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            app.UseAuthorization();
#else
            app.UseHangfireDashboard();
            LinxMicrovixERPRecurringJobsExtensions.AddRecurringJobs();
            LinxMicrovixB2CRecurringJobsExtensions.AddRecurringJobs();
#endif
            return app;
        }
    }
}
