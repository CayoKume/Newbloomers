using Domain.Core.Entities.Parameters;
using Infrastructure.Core.Data.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Reflection;

namespace Infrastructure.Movidesk.Data
{
    public abstract class BaseMovideskContext : DbContext
    {
        private readonly IConfiguration _configuration;
        private readonly string _schema;

        protected BaseMovideskContext(DbContextOptions options, IConfiguration configuration, string schema)
            : base(options)
        {
            _configuration = configuration;
            _schema = schema;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var methods = _configuration.GetSection("Movidesk:Methods").Get<List<Methods>>() ?? new List<Methods>();
            var entitiesToIgnore = methods
                .Where(x => !x.IsActive)
                .Select(x => $"Domain.Movidesk.Entities.{x.MethodName}")
                .ToList();

            modelBuilder.ApplyConfigurationsFromAssembly(
                Assembly.GetExecutingAssembly(),
                (type) => type.Namespace != null && type.Namespace.EndsWith(_schema)
            );

            modelBuilder.ApplyCustomColumnTypeMappings(this);
            modelBuilder.IgnoreEntitiesBasedOnConfiguration("Domain.Movidesk", entitiesToIgnore);

            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                entityType.SetSchema(_schema);
            }
        }
    }

    public class GeneralMovideskContext : BaseMovideskContext
    {
        public GeneralMovideskContext(DbContextOptions<GeneralMovideskContext> options, IConfiguration configuration)
            : base(options, configuration, "general") { }
    }

    public class UntreatedMovideskContext : BaseMovideskContext
    {
        public UntreatedMovideskContext(DbContextOptions<UntreatedMovideskContext> options, IConfiguration configuration)
            : base(options, configuration, "untreated") { }
    }
}