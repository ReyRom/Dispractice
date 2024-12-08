using Microsoft.EntityFrameworkCore;

namespace Dispractice.Models
{
    public class MilitaryServiceContext : DbContext
    {
        public DbSet<Serviceman> Servicemen { get; set; }
        public DbSet<MilitaryPosition> MilitaryPositions { get; set; }
        public DbSet<Commendation> Commendations { get; set; }
        public DbSet<Penalty> Penalties { get; set; }

        public MilitaryServiceContext(DbContextOptions<MilitaryServiceContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Дополнительная настройка моделей (если требуется)
        }
    }
}
