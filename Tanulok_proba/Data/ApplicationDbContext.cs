using Microsoft.EntityFrameworkCore;
using Tanulok_proba.Model;

namespace Tanulok_proba.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Diak> Diakok { get; set; }
        public DbSet<Tanar> Tanarok { get; set; }
        public DbSet<TanarDiak> TanarDiak { get; set; } 

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}
