using Avalonia;
using Microsoft.EntityFrameworkCore;

namespace Dispractice.Models
{
    public class MilitaryServiceContext : DbContext
    {
        public DbSet<Serviceman> Servicemans { get; set; } = null!;
        public DbSet<MilitaryPosition> MilitaryPositions { get; set; } = null!;

        public DbSet<MilitaryUnit> MilitaryUnits { get; set; } = null!;
        public DbSet<Commendation> Commendations { get; set; } = null!;
        public DbSet<Penalty> Penalties { get; set; } = null!;

        public MilitaryServiceContext(DbContextOptions<MilitaryServiceContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(App.Configuration.GetSection("ConnectionStrings")["DefaultConnection"]);

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MilitaryUnit>().Property(x => x.Id).ValueGeneratedOnAdd();
            modelBuilder.Entity<MilitaryUnit>().HasData(
                new MilitaryUnit() { Id = 1, Name = "Воинская часть", ParentUnitId = null }
            );
            modelBuilder.Entity<MilitaryPosition>()
                .HasOne(e => e.Serviceman)
                .WithOne(e => e.MilitaryPosition)
                .HasForeignKey<Serviceman>(e => e.MilitaryPositionId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.SetNull);

            base.OnModelCreating(modelBuilder);
        }
    }
}
