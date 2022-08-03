namespace LoanApplicationAPI.Domain.LoanDecisionRules
{
    public class LoanDecisionFactory: ILoanDecisionFactory
    {
        public ILoanDecisionRule GetLoanDecisionRule(LoanProductType type)
        {
            switch (type)
            {
                case LoanProductType.Default:
                    return new DefaultLoanDecisionRule();

                // When more rules are added other DecisionRules will be returned
                default:
                    return new DefaultLoanDecisionRule();
            }
        }
    }
}
