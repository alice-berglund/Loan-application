using FluentAssertions;
using LoanApplicationAPI.Domain.State;

namespace LoanApplication.DomainTests
{
    public class When_creating_a_loan_application
    {
        private readonly LoanApplicationAPI.Domain.LoanApplication _loanApplication;

        public When_creating_a_loan_application()
        {
            _loanApplication = new LoanApplicationAPI.Domain.LoanApplication("Pepe", "Silva", "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 33000, 0);
        }

        [Fact]
        public void Loan_application_is_created()
        {
            var state = (LoanApplicationState)_loanApplication;
            state.Should().BeEquivalentTo(new LoanApplicationState
            {
                FirstName = "Pepe",
                LastName = "Silva",
                Adress = "Silent Third Harbor 258",
                Zip = "14628",
                Street = "Silent Third Harbor",
                LoanAmount = 100000,
                LoanDurationInMonths = 18,
                MonthlyIncome = 33000,
                ProductType = 0,
                Id = _loanApplication.Id
            });

        }
    }
}