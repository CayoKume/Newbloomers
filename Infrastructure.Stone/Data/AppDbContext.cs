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
        }
    }
}
