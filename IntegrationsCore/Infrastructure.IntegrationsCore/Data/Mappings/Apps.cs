using Domain.IntegrationsCore.Entities.Auditing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.IntegrationsCore.Data.Mappings
{
    public class AppsMap : IEntityTypeConfiguration<App>
    {
        public void Configure(EntityTypeBuilder<App> builder)
        {
            builder.ToTable("Apps");

            builder.HasKey(e => e.IdParent);

            builder.Property(e => e.IdParent)
                .HasColumnType("int");

            builder.Property(e => e.Title)
                .HasColumnType("varchar(50)");

            builder.Property(e => e.Description)
                .HasColumnType("varchar(250)");

            builder.HasData(
                new App ( IdParent: 1,	Title: "NewBloomers", Description: "Grupo de Sistemas NewBloomers" ),
                new App ( IdParent: 10, Title: "LINX_MICROVIX_ERP", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 11, Title: "LINX_MICROVIX_COMMERCE", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 12, Title: "LINX_COMMERCE", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 13, Title: "GENERAL", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 14, Title: "OPERATIONS", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 15, Title: "CRM", Description: "Schema do Database NewBloomers" ),
                new App ( IdParent: 20, Title: "Jobs", Description: "Grupo de Trabalhos Realizados pelos Sistemas" ),
                new App ( IdParent: 30, Title: "Jobs de Integrações", Description: "Grupo de Trabalhos Realizados pelos Sistemas de Integrações C#" ),
                new App ( IdParent: 40, Title: "Procedures", Description: "Procedures Realizadas no Database NewBloomers" ),
                new App ( IdParent: 50, Title: "Integrações/ERP", Description: "Sistema de Integrações do ERP" ),
                new App ( IdParent: 51, Title: "Integrações/ECOMMERCE", Description: "Sistema de Integrações do Ecommerce" ),
                new App ( IdParent: 52, Title: "Integrações/B2C", Description: "Sistema de Integrações do Ecommerce após Integração Nativa do ERP" ),
                new App ( IdParent: 53, Title: "Integrações/Dootax", Description: "Sistema Integrações da Dootax" ),
                new App ( IdParent: 54, Title: "Integrações/AfterSale", Description: "Sistema Integrações da AfterSale" ),
                new App ( IdParent: 55, Title: "Integrações/Mobsim", Description: "Sistema Integrações da Mobsim" ),
                new App ( IdParent: 56, Title: "Integrações/Movidesk", Description: "Sistema Integrações da Movidesk" ),
                new App ( IdParent: 57, Title: "Integrações/Pagarme", Description: "Sistema Integrações da Pagarme" ),
                new App ( IdParent: 58, Title: "Integrações/TotalExpress", Description: "Sistema Integrações da TotalExpress" ),
                new App ( IdParent: 59, Title: "Integrações/FlashCourier", Description: "Sistema Integrações da FlashCourier" ),
                new App ( IdParent: 60, Title: "Integrações/JadLog", Description: "Sistema Integrações da JadLog"),
                new App ( IdParent: 70, Title: "Integrações/Stone", Description: "Sistema Integrações da Stone")
            );
        }
    }
}
