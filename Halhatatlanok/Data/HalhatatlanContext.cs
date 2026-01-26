using Microsoft.EntityFrameworkCore;

namespace Halhatatlanok.Data
{
    public class HalhatatlanContext : DbContext
    {
        public DbSet<Models.Kategoria> Kategoriak { get; set; } = null!;
        public DbSet<Models.Tag> Tagok { get; set; } = null!;
        public HalhatatlanContext(DbContextOptions<HalhatatlanContext> options) : base(options)
        {
        }
    }
}
