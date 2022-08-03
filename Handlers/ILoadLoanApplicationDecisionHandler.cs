using LoanApplicationAPI.Domain;

namespace LoanApplicationAPI.Handlers
{
    public interface ILoadLoanApplicationDecisionHandler
    {
        Task<Result<LoanApplicationDecision>> Handler(Guid loanApplicationId);
    }
}
