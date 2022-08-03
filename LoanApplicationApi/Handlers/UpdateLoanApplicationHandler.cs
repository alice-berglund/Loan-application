using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Domain.LoanDecisionRules;
using LoanApplicationAPI.Domain.State;
using LoanApplicationAPI.Requests;

namespace LoanApplicationAPI.Handlers
{
    public class UpdateLoanApplicationHandler : IUpdateLoanApplicationHandler
    {
        private readonly LoanApplicationDbContext _dbContext;
        private readonly ILoanDecisionFactory _loanDecisionFactory;

        public UpdateLoanApplicationHandler(LoanApplicationDbContext dbContext, ILoanDecisionFactory loanDecisionFactory)
        {
            _dbContext = dbContext;
            _loanDecisionFactory = loanDecisionFactory;
        }

        public async Task<Result<LoanApplication>> Handler(Guid id, UpdateLoanApplicationRequest updateLoanApplicationRequest)
        {
            var loanApplication = await _dbContext.LoadLoanApplication(id);

            if (loanApplication is null)
                return Result<LoanApplication>.Error("No loan application found with this Id");

            loanApplication.UpdateLoanApplication(
                    updateLoanApplicationRequest.FirstName,
                    updateLoanApplicationRequest.LastName,
                    updateLoanApplicationRequest.Adress,
                    updateLoanApplicationRequest.Zip,
                    updateLoanApplicationRequest.Street,
                    updateLoanApplicationRequest.LoanAmount,
                    updateLoanApplicationRequest.LoanDurationInMonths,
                    updateLoanApplicationRequest.MonthlyIncome,
                    updateLoanApplicationRequest.ProductType
            );

            var approved = _loanDecisionFactory
                .GetLoanDecisionRule(loanApplication.ProductType)
                .MakeDecision(loanApplication);

            loanApplication.MakeLoanApplicationDecision(approved);

            await _dbContext.SaveChangesAsync();

            return Result<LoanApplication>.Success(loanApplication);
        }
    }
}
