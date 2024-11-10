using Hangfire;

namespace HangfireDashboard.Domain.Extensions
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, string? serverName)
        {
            #if DEBUG
                app.UseSwagger();
                app.UseSwaggerUI();
                app.UseHttpsRedirection();
                app.UseAuthorization();
            #else
                app.UseHangfireDashboard();
                RecurringJobsExtensions.AddRecurringJobs(serverName);
            #endif
                return app;
        }
    }
}
