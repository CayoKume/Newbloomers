using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.IntegrationsCore.Data.Extensions
{
    public static class ModelBuilderIgnoreEntitiesExtensions
    {
        /// <summary>
        /// Ignora entidades com base nas configurações no IConfiguration.
        /// </summary>
        public static void IgnoreEntitiesBasedOnConfiguration(this ModelBuilder modelBuilder, string domainAssemblyName, List<string> entitiesToIgnore)
        {
            var domainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == domainAssemblyName);

            //var entitiesToIgnore = new List<string>();

            //// Lógica para LinxMicrovix
            //var linxMicrovixMethods = configuration
            //    .GetSection("LinxMicrovix:Methods")
            //    .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            //entitiesToIgnore.AddRange(linxMicrovixMethods
            //    .Where(x => !x.IsActive)
            //    .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entites.LinxMicrovix.{x.MethodName}"));

            //// Lógica para B2CLinxMicrovix
            //var b2cLinxMicrovixMethods = configuration
            //    .GetSection("B2CLinxMicrovix:Methods")
            //    .Get<List<LinxMethods>>() ?? new List<LinxMethods>();

            //entitiesToIgnore.AddRange(b2cLinxMicrovixMethods
            //    .Where(x => !x.IsActive)
            //    .Select(x => $"Domain.LinxMicrovix.Outbound.WebService.Entites.LinxCommerce.{x.MethodName}"));

            foreach (var entityTypeName in entitiesToIgnore.Distinct())
            {
                var type = domainAssembly.GetType(entityTypeName);

                if (type != null)
                    modelBuilder.Ignore(type);
            }
        }
    }
}
