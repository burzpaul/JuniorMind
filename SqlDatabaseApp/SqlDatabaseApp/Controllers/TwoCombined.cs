using Microsoft.EntityFrameworkCore;

namespace SqlDatabaseApp.Controllers
{
    public partial class TwoCombined : DbContext
    {
        public DbSet<Artist> Artist { get; set; }
        public DbSet<Album> Album { get; set; }
    }
}