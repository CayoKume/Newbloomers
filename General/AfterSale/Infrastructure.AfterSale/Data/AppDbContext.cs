using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Infrastructure.AfterSale.Data
{
    public class AfterSaleDbContext(DbContextOptions<AfterSaleDbContext> options) : DbContext(options)
    {
        //public DbSet<>  { get; set; } = null!;
    }
}
