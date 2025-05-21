using Application.IntegrationsCore.Interfaces;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.IntegrationsCore.Data.Extensions
{
    public static class ModelBuilderSchemaExtensions
    {
        /// <summary>
        /// Limpa o contexto de schema e registra os schemas baseados nos namespaces das entidades.
        /// Isso é feito antes da construção final do modelo pelo EF Core.
        /// </summary>
        public static void RegisterAndSetInitialSchemas(Type entityType, string schema)
        {
            SchemaContext.Clear();

            SchemaContext.RegisterSchema(entityType, schema);
        }

        /// <summary>
        /// Aplica o schema final a cada tipo de entidade no modelo, baseado nos schemas registrados.
        /// </summary>
        public static void ApplySchemasToEntityTypes(this ModelBuilder modelBuilder)
        {
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                var clrType = entityType.ClrType;
                if (clrType == null) continue;

                // Obtém o schema do SchemaContext, que já foi populado com a lógica de namespace
                var schema = SchemaContext.GetSchema(clrType);

                if (!string.IsNullOrEmpty(schema))
                {
                    entityType.SetSchema(schema);
                }
            }
        }
    }
}
