using Domain.IntegrationsCore.Models.Parameters;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.AfterSale.Data
{
    public class AfterSaleTreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AfterSaleTreatedDbContext(DbContextOptions<AfterSaleTreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("AfterSale:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.AfterSale.Entities.{x.MethodName}"));

            var configTypes = typeof(AfterSaleTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "general");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.AfterSale.DependencyInjection.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.AfterSale", entitiesToIgnore);

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "general");
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetSchema("general");
            }
        }
    }

    public class AfterSaleUntreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public AfterSaleUntreatedDbContext(DbContextOptions<AfterSaleUntreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("AfterSale:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.AfterSale.Entities.{x.MethodName}"));

            var configTypes = typeof(AfterSaleUntreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.AfterSale.DependencyInjection.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.AfterSale", entitiesToIgnore);

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetSchema("untreated");
            }
        }
    }
}
