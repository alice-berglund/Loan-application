namespace LoanApplicationAPI.Domain.LoanDecisionRules
{
    public class DefaultLoanDecisionRule: ILoanDecisionRule
    {
        public bool MakeDecision(LoanApplication loanApplication)
        {
            if (loanApplication.MonthlyIncome > 31000)
                return true;

            return false;
        }
    }
}
