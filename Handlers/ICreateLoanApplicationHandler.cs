using LoanApplicationAPI.Domain;
using LoanApplicationAPI.Requests;

namespace LoanApplicationAPI.Handlers
{
    public interface ICreateLoanApplicationHandler
    {
        Task<Result<LoanApplication>> Handler(CreateLoanApplicationRequest createLoanApplicationRequest);
    }
}
