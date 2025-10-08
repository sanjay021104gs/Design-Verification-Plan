using DVP.Models;
using System.Data.Entity;

namespace DVP.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Models.DvpFormEntry> DvpFormEntries { get; set; }
        public DbSet<TestDetail> TestDetails { get; set; }
        public DbSet<ApprovalSignatures> ApprovalSignatures { get; set; }

        public DbSet<TestRecord> TestRecords { get; set; }
        public DbSet<DvpDraftData> DvpDrafts { get; set; }


    }
}
