using LoanApplicationAPI.Domain.LoanDecisionRules;

namespace LoanApplicationAPI.Domain.State
{
    public class LoanApplicationState
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanDurationInMonths { get; set; }
        public decimal MonthlyIncome { get; set; }
        public LoanProductType ProductType { get; set; }

        //navigation
        public LoanApplicationDecisionState LoanApplicationDecision { get; set; }
    }
}
