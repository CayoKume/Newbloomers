using Microsoft.EntityFrameworkCore;
namespace Infrastructure.FlashCourier.Data
{
    public class FlashCourierDbContext(DbContextOptions<FlashCourierDbContext> options) : DbContext(options)
    {

    }
}
