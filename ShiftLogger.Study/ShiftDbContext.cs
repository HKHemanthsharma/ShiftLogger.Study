using Microsoft.EntityFrameworkCore;
using ShiftLogger.Study.Model;

namespace ShiftLogger.Study
{
    public class ShiftDbContext : DbContext
    {
        public ShiftDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Shift>()
                .Property(x => x.ShiftDuration)
                .HasConversion(
                v => (int)(v.Seconds - v.ShiftStartTime).TotalMinutes;
        }
    }
}
