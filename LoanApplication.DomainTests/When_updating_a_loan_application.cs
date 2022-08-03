using FluentAssertions;
using LoanApplicationAPI.Domain.State;

namespace LoanApplication.DomainTests
{
    public class When_updating_a_loan_application
    {
        private readonly LoanApplicationAPI.Domain.LoanApplication _loanApplication = new LoanApplicationAPI.Domain.LoanApplication(new LoanApplicationAPI.Domain.State.LoanApplicationState
        {
            FirstName = "Pepe",
            LastName = "Silva",
            Adress = "Silent Third Harbor 258",
            Zip = "14628",
            Street = "Silent Third Harbor",
            LoanAmount = 100000,
            LoanDurationInMonths = 18,
            MonthlyIncome = 33000,
            ProductType = 0
        });

        public When_updating_a_loan_application()
        {
            _loanApplication.UpdateLoanApplication("Pepe", "Silva", "Shady Spur Highway 600", "68371", "Shady Spur Highway", 100000, 18, 33000, 0);
        }

        [Fact]
        public void Loan_application_is_updated()
        {
            var state = (LoanApplicationState)_loanApplication;
            state.Should().BeEquivalentTo(new LoanApplicationState
            {
                FirstName = "Pepe",
                LastName = "Silva",
                Adress = "Shady Spur Highway 600",
                Zip = "68371",
                Street = "Shady Spur Highway",
                LoanAmount = 100000,
                LoanDurationInMonths = 18,
                MonthlyIncome = 33000,
                ProductType = 0
            });

        }
    }
}
