namespace LoanApplication.DomainTests
{
    public class When_updating_a_loan_application_when_missing_required_values
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

        [Fact]
        public void When_first_name_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => _loanApplication.UpdateLoanApplication(null, "Silva", "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_last_name_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => _loanApplication.UpdateLoanApplication("Pepe", null, "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_adress_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => _loanApplication.UpdateLoanApplication("Pepe", "Silva", null, "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_zip_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => _loanApplication.UpdateLoanApplication("Pepe", "Silva", "Silent Third Harbor 258", null, "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_street_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => _loanApplication.UpdateLoanApplication("Pepe", "Silva", "Silent Third Harbor 258", "14628", null, 100000, 18, 33000, 0));
        }
    }
}
