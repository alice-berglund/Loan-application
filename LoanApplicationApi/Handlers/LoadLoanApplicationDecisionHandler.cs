using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Domain.State;
using Microsoft.EntityFrameworkCore;

namespace LoanApplicationAPI.Handlers
{
    public class LoadLoanApplicationDecisionHandler: ILoadLoanApplicationDecisionHandler
    {
        private readonly LoanApplicationDbContext _dbContext;

        public LoadLoanApplicationDecisionHandler(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<LoanApplicationDecision>> Handler(Guid loanApplicationId)
        {
            var loanApplicationDecision = await _dbContext
                .LoanApplications
                .WhereId(loanApplicationId)
                .Select(loanApplication => new LoanApplicationDecision(loanApplication.LoanApplicationDecision))
                .AsNoTracking()
                .SingleAsync();

            if (loanApplicationDecision == null)
                return Result<LoanApplicationDecision>.Error("No loan application decision found with this Id");

            return Result<LoanApplicationDecision>.Success(loanApplicationDecision);
        }
    }
}
