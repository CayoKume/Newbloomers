using Microsoft.EntityFrameworkCore;

namespace Infrastructure.TotalExpress.Data
{
    public class TotalExpressDbContext(DbContextOptions<TotalExpressDbContext> options) : DbContext(options)
    {

    }
}
