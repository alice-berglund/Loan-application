namespace LoanApplicationAPI.Domain.LoanDecisionRules
{
    public interface ILoanDecisionFactory
    {
        ILoanDecisionRule GetLoanDecisionRule(LoanProductType type);
    }
}
