using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IntegrationsCore.Data.Extensions
{
    public static class ModelBuilderColumnTypeExtensions
    {
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

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                foreach (var property in entityType.GetProperties())
                {
                    var columnTypeAnnotation = property.FindAnnotation("Custom:ColumnTypeMapper");
                    if (columnTypeAnnotation != null)
                    {
                        var logicalType = columnTypeAnnotation.Value?.ToString();

                        //if (logicalType != null && typeMappings.TryGetValue(logicalType, out var dbType))
                        //{
                        //    property.SetColumnType(dbType);
                        //}
                    }
                }
            }
        }
    }
}
