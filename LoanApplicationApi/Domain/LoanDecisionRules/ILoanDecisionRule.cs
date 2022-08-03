namespace LoanApplicationAPI.Domain.LoanDecisionRules
{
    public interface ILoanDecisionRule
    {
        bool MakeDecision(LoanApplication loanApplication);
    }
}
