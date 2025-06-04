using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Jadlog.Data
{
    public class JadlogDbContext(DbContextOptions<JadlogDbContext> options) : DbContext(options)
    {

    }
}
