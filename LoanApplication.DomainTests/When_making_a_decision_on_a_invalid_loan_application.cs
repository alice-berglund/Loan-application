using LoanApplicationAPI.Domain.LoanDecisionRules;

namespace LoanApplication.DomainTests
{
    public class When_making_a_decision_on_a_invalid_loan_application
    {
        private readonly LoanApplicationAPI.Domain.LoanApplication _loanApplication;
        private readonly ILoanDecisionFactory _loanDecisionFactory = new LoanDecisionFactory();

        public When_making_a_decision_on_a_invalid_loan_application()
        {
            _loanApplication = new LoanApplicationAPI.Domain.LoanApplication("Pepe", "Silva", "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 23000, 0);
        }

        [Fact]
        public void Loan_application_decision_should_not_be_approved()
        {
            var approved = _loanDecisionFactory
                .GetLoanDecisionRule(_loanApplication.ProductType)
                .MakeDecision(_loanApplication);

            _loanApplication.MakeLoanApplicationDecision(approved);

            Assert.False(approved);

        }
    }
}