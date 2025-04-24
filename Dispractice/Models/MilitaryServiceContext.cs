using Avalonia;
using Microsoft.EntityFrameworkCore;

namespace Dispractice.Models
{
    public class MilitaryServiceContext : DbContext
    {
        public DbSet<Serviceman> Servicemans { get; set; } = null!;
        public DbSet<Position> Positions { get; set; } = null!;

        public DbSet<Unit> Units { get; set; } = null!;
        public DbSet<Commendation> Commendations { get; set; } = null!;
        public DbSet<Penalty> Penalties { get; set; } = null!;

        public MilitaryServiceContext(DbContextOptions<MilitaryServiceContext> options)
            : base(options)
        {
        }
         
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Unit>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<Unit>().HasData(
                new Unit() { Id = 1, Name = "Воинская часть", ParentUnitId = null }
            );
            modelBuilder.Entity<Position>()
                .HasOne(e => e.Serviceman)
                .WithOne(e => e.Position)
                .HasForeignKey<Serviceman>(e => e.PositionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Commendation>().Property(x=>x.Type).HasConversion<string>();
            modelBuilder.Entity<Penalty>().Property(x => x.Type).HasConversion<string>();
            modelBuilder.Entity<Serviceman>().Property(x => x.Rank).HasConversion<string>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
