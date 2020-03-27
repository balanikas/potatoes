using Microsoft.EntityFrameworkCore;

namespace PotatoShop
{
    public class AppContext : DbContext
    {
        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
        }

        public DbSet<Potato> Potatoes { get; set; }
    }
}
