using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using ShiftLogger.Study.Model;
using System.Linq;

namespace ShiftLogger.Study
{
    public class ShiftDbContext : DbContext
    {
        public ShiftDbContext(DbContextOptions options) : base(options) { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
        }
        public override int SaveChanges()
        {
            var Entities = ChangeTracker.Entries<Shift>().Where(x => new List<EntityState> { EntityState.Added,EntityState.Modified, EntityState.Deleted}.Contains(x.State))
            .Select(x=>x).ToList();
            foreach (var entity in Entities)
            {
                entity.Entity.CalculateDuration();
            }
            base.SaveChanges();
            return Entities.Count();
        }
           
        }
    }
}
