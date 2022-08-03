using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI.Domain.State
{
    public static class LoanApplicationStateExtenstions
    {
        public static IQueryable<LoanApplication> SelectDomainModel(this IQueryable<LoanApplicationState> loanApplications)
        {
            return loanApplications
                .Include(loanApplication => loanApplication.LoanApplicationDecision)
                .Select(loanApplication => new LoanApplication(loanApplication));
        }

        public static IQueryable<LoanApplicationState> WhereId(this IQueryable<LoanApplicationState> loanApplications, Guid id)
        {
            return loanApplications.Where(loanApplication => loanApplication.Id == id);
        }

        public static Task<LoanApplication> LoadLoanApplication(this LoanApplicationDbContext dbContext, Guid id)
        {
            return dbContext.LoanApplications.WhereId(id).SelectDomainModel().SingleAsync();
        }
    }
}
