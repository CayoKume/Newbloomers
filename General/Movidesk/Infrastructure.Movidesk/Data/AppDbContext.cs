using Domain.IntegrationsCore.Models.Parameters;
using Infrastructure.IntegrationsCore.Data.Extensions;
using Infrastructure.IntegrationsCore.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Movidesk.Data
{
    public class MovideskTreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MovideskTreatedDbContext(DbContextOptions<MovideskTreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Movidesk:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Movidesk.Entities.{x.MethodName}"));

            var configTypes = typeof(MovideskTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "general");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Movidesk.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Movidesk", entitiesToIgnore);

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

    public class MovideskUntreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public MovideskUntreatedDbContext(DbContextOptions<MovideskUntreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Movidesk:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Movidesk.Entities.{x.MethodName}"));

            var configTypes = typeof(MovideskUntreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Movidesk.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Movidesk", entitiesToIgnore);

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
