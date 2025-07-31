using Domain.Core.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.VisualBasic;
using System.Diagnostics;

namespace Infrastructure.Core.Data.Mappings
{
    public class MessageLevelsMap : IEntityTypeConfiguration<MessageLevel>
    {
        public void Configure(EntityTypeBuilder<MessageLevel> builder)
        {
            builder.ToTable("MessageLevels");

            builder.HasKey(e => e.IdLogLevel);

            builder.Property(e => e.IdLogLevel)
                .HasColumnType("int");

            builder.Property(e => e.Title)
                .HasColumnType("varchar(30)");

            builder.Property(e => e.Description)
                .HasColumnType("varchar(300)");

            builder.Property(e => e.EnumLevelName)
                .HasColumnType("varchar(30)");

            builder.HasData(
                new MessageLevel( IdLogLevel: 1, Title: "Undefined",   Description: null, EnumLevelName: "0" ),
                new MessageLevel( IdLogLevel: 2, Title: "Debug",       Description: null, EnumLevelName: "1" ),
                new MessageLevel( IdLogLevel: 3, Title: "Information", Description: null, EnumLevelName: "2" ),
                new MessageLevel( IdLogLevel: 4, Title: "Warning",     Description: null, EnumLevelName: "3" ),
                new MessageLevel( IdLogLevel: 5, Title: "Error",       Description: null, EnumLevelName: "4" ),
                new MessageLevel( IdLogLevel: 6, Title: "Critical",    Description: null, EnumLevelName: "5" ),
                new MessageLevel( IdLogLevel: 7, Title: "Validations", Description: null, EnumLevelName: "6" ),
                new MessageLevel( IdLogLevel: 8, Title: "Trace",       Description: null, EnumLevelName: "7" )
            );
        }
    }
}
