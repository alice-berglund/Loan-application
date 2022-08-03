using LoanApplicationAPI.Domain.State;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI
{
    public class LoanApplicationDbContext : DbContext
    {
        public DbSet<LoanApplicationState> LoanApplications { get; set; }

        public LoanApplicationDbContext(DbContextOptions options): base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<LoanApplicationState>()
                .ToTable("LoanApplication", b => b.IsTemporal());

            modelBuilder
                .Entity<LoanApplicationState>()
                .OwnsOne(loanApplication => 
                    loanApplication.LoanApplicationDecision,
                    e => e.ToTable("LoanApplicationDecision", b => b.IsTemporal()));

            modelBuilder
                .Entity<LoanApplicationState>()
                .Property(loanApplication => loanApplication.ProductType).HasConversion<int>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
