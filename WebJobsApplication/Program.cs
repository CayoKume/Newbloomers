using WebJobsApplication.Domain.Extensions;

namespace WebJobsApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = Host.CreateDefaultBuilder();
            
            builder
                .AddServices()
                .ConfigureWebJobs(b =>
                {
                    b.AddAzureStorageCoreServices();
                });

            var host = builder.Build();

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}