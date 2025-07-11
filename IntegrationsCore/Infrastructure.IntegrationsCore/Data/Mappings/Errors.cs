using Domain.IntegrationsCore.Enums;
using Domain.IntegrationsCore.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Error = Domain.IntegrationsCore.Entities.Auditing.Error;

namespace Infrastructure.IntegrationsCore.Data.Mappings
{
    public class ErrorsMap : IEntityTypeConfiguration<Error>
    {
        public void Configure(EntityTypeBuilder<Error> builder)
        {
            builder.ToTable("Errors");

            builder.HasKey(e => e.IdError);

            builder.Property(e => e.IdError)
                .HasColumnType("int");

            builder.Property(e => e._Error)
                .HasColumnName("Error")
                .HasColumnType("varchar(60)");

            builder.Property(e => e.Resolution)
                .HasColumnType("varchar(8000)");

            builder.Property(e => e.RequireUserAction)
                .HasProviderColumnType(EnumTableColumnType.Bool);

            builder.Property(e => e.EmergencyLevel)
                .HasColumnType("int");

            builder.Property(e => e.ActionInf)
                .HasColumnType("varchar(400)");

            builder.Property(e => e.EnumErrorName)
                .HasColumnType("varchar(60)");

            builder.HasData(
                new Error ( IdError: 1, _Error: "Undefined", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 2, _Error: "ExceptionBase", Resolution: null , RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 3, _Error: "Validation", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 4, _Error: "LegthValidation", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 5, _Error: "ConvertValidation", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 6, _Error: "ArgumentConectionStringIsNull", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 7, _Error: "ArgumentoInvalido", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 8, _Error: "SQLCommand", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 9, _Error: "APIException", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 10, _Error: "EndPointReturnEmpty", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 11, _Error: "EndPointFailOnDeserialize", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 12, _Error: "CreateClientException", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 13, _Error: "SqlInsert", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null ),
                new Error ( IdError: 14, _Error: "Compare", Resolution: null, RequireUserAction: null, EmergencyLevel: null, ActionInf: null, EnumErrorName: null )
            );
        }
    }
}
