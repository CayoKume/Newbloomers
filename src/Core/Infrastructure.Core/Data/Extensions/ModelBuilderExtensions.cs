using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Core.Data.Extensions
{
    public static class ModelBuilderExtensions
    {
        /// <summary>
        /// Aplica o schema final a cada tipo de entidade no modelo, baseado nos schemas registrados.
        /// </summary>
        public static void ApplySchemasToEntityTypes(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;

                // Obtém o schema do SchemaContext, que já foi populado com a lógica de namespace
                var schema = SchemaContext.GetSchema(clrType);

                entityType.SetSchema(schema);
            }
        }

        /// <summary>
        /// Ignora entidades com base nas configurações no IConfiguration.
        /// </summary>
        public static void IgnoreEntitiesBasedOnConfiguration(this ModelBuilder modelBuilder, string domainAssemblyName, List<string> entitiesToIgnore)
        {
            var domainAssembly = AppDomain.CurrentDomain.GetAssemblies().FirstOrDefault(a => a.GetName().Name == domainAssemblyName);

            foreach (var entityTypeName in entitiesToIgnore.Distinct())
            {
                var type = domainAssembly.GetType(entityTypeName);

                if (type != null)
                    modelBuilder.Ignore(type);
            }
        }

        /// <summary>
        /// Aplica os tipos de coluna personalizados definidos via anotação "Custom:ColumnTypeMapper".
        /// </summary>
        public static void ApplyCustomColumnTypeMappings(this ModelBuilder modelBuilder, DbContext context)
        {
            string? providerName = context.Database.ProviderName;
            string? providerKey = providerName?.Contains("SqlServer") == true ? "SqlServer" :
                                  providerName?.Contains("Npgsql") == true ? "PostgreSQL" :
                                  providerName?.Contains("MySql") == true ? "MySql" :
                                  null;

            var typeMappings = ProviderColumnTypes.Mappings[providerKey];

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var columnTypeAnnotation = property.FindAnnotation("Custom:ColumnTypeMapper");
                    if (columnTypeAnnotation != null)
                    {
                        var logicalType = columnTypeAnnotation.Value?.ToString();

                        if (logicalType != null && typeMappings.TryGetValue(logicalType, out var dbType))
                        {
                            property.SetColumnType(dbType);
                        }
                    }
                }
            }
        }
    }
}
