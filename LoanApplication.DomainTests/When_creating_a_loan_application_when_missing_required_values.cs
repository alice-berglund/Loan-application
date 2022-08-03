namespace LoanApplication.DomainTests
{
    public class When_creating_a_loan_application_when_missing_required_values
    {
        [Fact]
        public void When_first_name_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => new LoanApplicationAPI.Domain.LoanApplication(null, "Silva", "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_last_name_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => new LoanApplicationAPI.Domain.LoanApplication("Pepe", null, "Silent Third Harbor 258", "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_adress_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => new LoanApplicationAPI.Domain.LoanApplication("Pepe", "Silva", null, "14628", "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_zip_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => new LoanApplicationAPI.Domain.LoanApplication("Pepe", "Silva", "Silent Third Harbor 258", null, "Silent Third Harbor", 100000, 18, 33000, 0));
        }

        [Fact]
        public void When_street_is_missing_null_exception_is_thrown()
        {
            Assert.Throws<ArgumentNullException>(() => new LoanApplicationAPI.Domain.LoanApplication("Pepe", "Silva", "Silent Third Harbor 258", "14628", null, 100000, 18, 33000, 0));
        }
    }
}
