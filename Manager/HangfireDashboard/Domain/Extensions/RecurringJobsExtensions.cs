using Hangfire;
using FlashCourier.Application.Services;

namespace HangfireDashboard.Domain.Extensions
{
    public static class RecurringJobsExtensions
    {
        public static void AddRecurringJobs(string? serverName)
        {
            if (serverName == "SRV-VM-APP02")
            {
                //SELECIONAR JOBS PARA O SERVIDOR SRV-VM-APP02 RODAR
            }
            else if (serverName == "SRV-VM-APP01")
            {
                //SELECIONAR JOBS PARA O SERVIDOR SRV-VM-APP01 RODAR
            }
            else
            {
                //TESTE PARA SERVIDORES SEM NOME
                FlashCourierRecurringJobs();
            }
        }

        private static void FlashCourierRecurringJobs()
        {
            RecurringJob.AddOrUpdate<IFlashCourierService>("FlashCourierSendOrders", service => service.SendOrders(),
                Cron.MinuteInterval(3)
            //,queue: "srv-vm-app02"
            );

            RecurringJob.AddOrUpdate<IFlashCourierService>("FlashCourierUpdateLogOrders", service => service.UpdateLogOrders(),
                Cron.MinuteInterval(5)
            //,queue: "srv-vm-app02"
            );
        }
    }
}
