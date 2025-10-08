using System.Data.Entity;

namespace DVP.Models
{
    public class DvpContext : DbContext
    {
        public DvpContext()
            : base("name=DefaultConnection")
        {
        }

        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<DvpFormEntry> DvpFormEntries { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TestDetail>()
                .Property(p => p.TestCostPlan)
                .HasPrecision(18, 2);

            modelBuilder.Entity<TestDetail>()
                .Property(p => p.TestCostActual)
                .HasPrecision(18, 2);

            base.OnModelCreating(modelBuilder);
        }
    }
}
