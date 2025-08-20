using Domain.Core.Entities.Parameters;
using Infrastructure.Core.Data.Extensions;
using Infrastructure.Core.Data.Schemas;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.Dootax.Data
{
    public class DootaxTreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DootaxTreatedDbContext(DbContextOptions<DootaxTreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Dootax:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Dootax.Entities.{x.MethodName}"));

            var configTypes = typeof(DootaxTreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "general");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Dootax.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Dootax", entitiesToIgnore);

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

    public class DootaxUntreatedDbContext : DbContext
    {
        private readonly IConfiguration _configuration;

        public DootaxUntreatedDbContext(DbContextOptions<DootaxUntreatedDbContext> options, IConfiguration configuration)
        : base(options) =>
            _configuration = configuration;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var entitiesToIgnore = new List<string>();

            var methods = _configuration
                .GetSection("Dootax:Methods")
                .Get<List<Methods>>() ?? new List<Methods>();

            entitiesToIgnore.AddRange(methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Dootax.Entities.{x.MethodName}"));

            var configTypes = typeof(DootaxUntreatedDbContext).Assembly.GetTypes()
                .Where(t => !t.IsAbstract && !t.IsInterface)
                .SelectMany(t => t.GetInterfaces()
                    .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IEntityTypeConfiguration<>))
                    .Select(i => new { ConfigType = t, EntityType = i.GetGenericArguments()[0] }))
                .ToList();

            foreach (var config in configTypes)
            {
                SchemaContext.RegisterSchema(config.EntityType, "untreated");
            }

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Infrastructure.Dootax.DependencyInjection).Assembly);

            modelBuilder.ApplyCustomColumnTypeMappings(this);

            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Dootax", entitiesToIgnore);

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
