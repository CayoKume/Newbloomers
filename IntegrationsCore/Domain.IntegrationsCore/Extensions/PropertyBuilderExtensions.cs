using Domain.IntegrationsCore.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.IntegrationsCore.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasProviderColumnType<TProperty>(
            this PropertyBuilder<TProperty> builder,
            LogicalColumnType logicalType)
        {
            return builder.HasAnnotation("Custom:ColumnTypeMapper", logicalType.ToString());
        }
    }
}
