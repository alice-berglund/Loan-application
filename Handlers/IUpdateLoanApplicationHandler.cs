using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Requests;

namespace LoanApplicationAPI.Handlers
{
    public interface IUpdateLoanApplicationHandler
    {
        Task<Result<LoanApplication>> Handler(Guid id, UpdateLoanApplicationRequest updateLoanApplicationRequest);
    }
}
