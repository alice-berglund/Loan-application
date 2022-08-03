using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Domain.State;

namespace LoanApplicationAPI.Handlers
{
    public class DeleteLoanApplicationHandler: IDeleteLoanApplicationHandler
    {
        private readonly LoanApplicationDbContext _dbContext;

        public DeleteLoanApplicationHandler(LoanApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Result<LoanApplication>> Handler(Guid id)
        {
            var loanApplication = await _dbContext.LoadLoanApplication(id);

            if (loanApplication == null)
                return Result<LoanApplication>.Error("No loan application found with this Id");

            _dbContext.LoanApplications.Remove(loanApplication);

            await _dbContext.SaveChangesAsync();

            return Result<LoanApplication>.Success(loanApplication);
        }
    }
}
