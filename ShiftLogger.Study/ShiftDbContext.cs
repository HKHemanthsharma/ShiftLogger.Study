using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ShiftLogger.Study.Model;
using System.Linq;

namespace ShiftLogger.Study
{
    public class ShiftDbContext : DbContext
    {
        public ShiftDbContext(DbContextOptions options) : base(options) { }
        public DbSet<Shift> Shifts { get; set; }
        public DbSet<Worker> Workers { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shift>()
                .HasKey(x => x.ShiftId);
            modelBuilder.Entity<Shift>()
                .Property(x => x.ShiftDate)
                .IsRequired();
            modelBuilder.Entity<Shift>()
                .Property(x => x.ShiftStartTime)
                .IsRequired();
            modelBuilder.Entity<Shift>()
                .Property(x => x.ShiftEndTime)
                .IsRequired();
            modelBuilder.Entity<Worker>()
                .HasKey(x => x.WorkerId);
            modelBuilder.Entity<Worker>()
                .HasMany(x => x.Shifts)
                .WithOne(x => x.Worker)
                .HasForeignKey(x => x.WorkerId);
        }
        public override int SaveChanges()
        {
            var Entities = ChangeTracker.Entries<Shift>().Where(x => new List<EntityState> { EntityState.Added,EntityState.Modified, EntityState.Deleted}.Contains(x.State))
            .Select(x=>x).ToList();
            foreach (var entity in Entities)
            {
                entity.Entity.CalculateDuration();
                entity.Entity.ShiftDate=entity.Entity.ShiftDate == null ? DateTime.Now.Date : entity.Entity.ShiftDate;
            }
            base.SaveChanges();
            return Entities.Count();
        }
    }
}
