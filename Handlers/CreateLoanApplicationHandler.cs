using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Domain.LoanDecisionRules;
using LoanApplicationAPI.Requests;
using LoanApplicationAPI.Handlers;

namespace LoanApplicationAPI.Handlers
{
    public class CreateLoanApplicationHandler: ICreateLoanApplicationHandler
    {
        private readonly LoanApplicationDbContext _dbContext;
        private readonly ILoanDecisionFactory _loanDecisionFactory;

        public CreateLoanApplicationHandler(LoanApplicationDbContext dbContext, ILoanDecisionFactory loanDecisionFactory)
        {
            _dbContext = dbContext;
            _loanDecisionFactory = loanDecisionFactory;
        }

        public async Task<Result<LoanApplication>> Handler(CreateLoanApplicationRequest createLoanApplicationRequest)
        {
            var loanApplication = new LoanApplication
                (
                    createLoanApplicationRequest.FirstName,
                    createLoanApplicationRequest.LastName,
                    createLoanApplicationRequest.Adress,
                    createLoanApplicationRequest.Zip,
                    createLoanApplicationRequest.Street,
                    createLoanApplicationRequest.LoanAmount,
                    createLoanApplicationRequest.LoanDurationInMonths,
                    createLoanApplicationRequest.MonthlyIncome,
                    createLoanApplicationRequest.ProductType
                );

            var approved = _loanDecisionFactory
                .GetLoanDecisionRule(loanApplication.ProductType)
                .MakeDecision(loanApplication);

            loanApplication.MakeLoanApplicationDecision(approved);

            _dbContext.LoanApplications.Add(loanApplication);

            await _dbContext.SaveChangesAsync();

            return Result<LoanApplication>.Success(loanApplication);
        }
    }
}
