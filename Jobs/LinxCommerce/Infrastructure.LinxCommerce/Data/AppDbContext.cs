using Microsoft.EntityFrameworkCore;

namespace Infrastructure.LinxCommerce.Data
{
    public class LinxCommerceDbContext(DbContextOptions<LinxCommerceDbContext> options) : DbContext(options)
    {

    }
}
