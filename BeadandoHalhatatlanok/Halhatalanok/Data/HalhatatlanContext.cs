using Microsoft.EntityFrameworkCore;

namespace Halhatatlanok.Data
{
    public class HalhatatlanContext : DbContext
    {
        public DbSet<Models.Kategoriak> Kategoriak { get; set; } = null!;
        public DbSet<Models.Tagok> Tagok { get; set; } = null!;
        public HalhatatlanContext(DbContextOptions<HalhatatlanContext> options) : base(options)
        {
        }
    }
}
