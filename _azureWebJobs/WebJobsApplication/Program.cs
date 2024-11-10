using WebJobsApplication.Domain.Extensions;

namespace WebJobsApplication
{
    public class Program
    {
        public static async Task Main(string[] args)
        {

            var configuration = new ConfigurationBuilder()
                .AddJsonFile($"appsettings.json")
                .Build();

            var builder = Host.CreateDefaultBuilder();
            
            builder
                .ConfigureWebJobs(b =>
                {
                    b
                    .AddAzureStorageCoreServices()
                    .AddTimers();
                })
                .AddServices()
                .UseConsoleLifetime();

            var host = builder.Build();
            await host.DatabaseInitialization(configuration);

            using (host)
            {
                await host.RunAsync();
            }
        }
    }
}