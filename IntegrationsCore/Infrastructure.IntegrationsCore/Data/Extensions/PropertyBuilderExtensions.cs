using Domain.IntegrationsCore.Entities.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.IntegrationsCore.Data.Extensions
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<TProperty> HasProviderColumnType<TProperty>(
            this PropertyBuilder<TProperty> builder,
            EnumTableColumnType logicalType)
        {
            return builder.HasAnnotation("Custom:ColumnTypeMapper", logicalType.ToString());
        }
    }
}
