using LoanApplicationAPI.Domain.LoanDecisionRules;

namespace LoanApplicationAPI.Requests
{
    public class CreateLoanApplicationRequest
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Adress { get; set; }
        public string Zip { get; set; }
        public string Street { get; set; }
        public decimal LoanAmount { get; set; }
        public int LoanDurationInMonths { get; set; }
        public decimal MonthlyIncome { get; set; }
        public LoanProductType ProductType { get; set; }
    }
}
