using Domain.Core.Enums;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Domain.Core.Extensions
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
