using Domain.IntegrationsCore.Entities.Parameters;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Stone.Data
{
    public class StoneTreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoneTreatedDbContext(DbContextOptions<StoneTreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Stone:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Stone.Entities.{x.MethodName}"));

            var configTypes = typeof(StoneTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "general");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Stone.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Stone", entitiesToIgnore);

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

    public class StoneUntreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public StoneUntreatedDbContext(DbContextOptions<StoneUntreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Stone:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Stone.Entities.{x.MethodName}"));

            var configTypes = typeof(StoneUntreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Stone.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Stone", entitiesToIgnore);

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
