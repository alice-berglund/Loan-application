using LoanApplicationAPI.Domain;

namespace LoanApplicationAPI.Handlers
{
    public interface IDeleteLoanApplicationHandler
    {
        Task<Result<LoanApplication>> Handler(Guid id);
    }
}
