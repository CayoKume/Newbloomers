﻿using Domain.IntegrationsCore.Extensions;

namespace Hangfire.IO.Extensions
{
    public static class AppUseExtensions
    {
        public static IApplicationBuilder UseApplication(this IApplicationBuilder app, string? serverName)
        {
            app.UseExceptionHandlingMiddleware();
#if DEBUG
            app.UseSwagger();
            app.UseSwaggerUI();
            app.UseHttpsRedirection();
            //app.UseAuthorization();
#else
            app.UseHangfireDashboard();
            LinxMicrovixERPRecurringJobsExtensions.AddRecurringJobs();
            LinxMicrovixB2CRecurringJobsExtensions.AddRecurringJobs();
#endif
            return app;
        }
    }
}
