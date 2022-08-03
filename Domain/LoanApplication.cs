using LoanApplicationAPI.Domain.LoanDecisionRules;
using LoanApplicationAPI.Domain.State;

namespace LoanApplicationAPI.Domain
{
    public class LoanApplication
    {
        private readonly LoanApplicationState _state;

        public Guid Id => _state.Id;
        public string FirstName => _state.FirstName;
        public string LastName => _state.LastName;
        public string Adress => _state.Adress;
        public string Zip => _state.Zip;
        public string Street => _state.Street;
        public decimal LoanAmount => _state.LoanAmount;
        public int LoanDurationInMonths => _state.LoanDurationInMonths;
        public decimal MonthlyIncome => _state.MonthlyIncome;
        public LoanProductType ProductType => _state.ProductType;

        public LoanApplicationDecision LoanApplicationDecision => new LoanApplicationDecision(_state.LoanApplicationDecision);

        public static implicit operator LoanApplicationState(LoanApplication loanApplication) => loanApplication._state;

        public LoanApplication(LoanApplicationState state)
        {
            _state = state;
        }

        public LoanApplication(
            string firstName,
            string lastname, 
            string adress, 
            string zip,
            string street,
            decimal loanAmount,
            int loanDurationInMonths,
            decimal monthlyIncome,
            LoanProductType productType)
        {
            _state = new LoanApplicationState
            {
                FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName)),
                LastName = lastname ?? throw new ArgumentNullException(nameof(lastname)),
                Adress = adress ?? throw new ArgumentNullException(nameof(adress)),
                Zip = zip ?? throw new ArgumentNullException(nameof(zip)),
                Street = street ?? throw new ArgumentNullException(nameof(street)),
                LoanAmount = loanAmount,
                LoanDurationInMonths = loanDurationInMonths,
                MonthlyIncome = monthlyIncome,
                Id = Guid.NewGuid(),
                ProductType = productType
            };
        }

        public LoanApplication UpdateLoanApplication(
            string firstName,
            string lastname,
            string adress,
            string zip,
            string street,
            decimal loanAmount,
            int loanDurationInMonths,
            decimal monthlyIncome,
            LoanProductType productType)
        {
            _state.FirstName = firstName ?? throw new ArgumentNullException(nameof(firstName));
            _state.LastName = lastname ?? throw new ArgumentNullException(nameof(lastname));
            _state.Adress = adress ?? throw new ArgumentNullException(nameof(zip));
            _state.Zip = zip ?? throw new ArgumentNullException(nameof(zip));
            _state.Street = street ?? throw new ArgumentNullException(nameof(street));
            _state.LoanAmount = loanAmount;
            _state.LoanDurationInMonths = loanDurationInMonths;
            _state.MonthlyIncome = monthlyIncome;
            _state.ProductType = productType;

            return this;
        }

        public LoanApplication MakeLoanApplicationDecision(bool approved)
        {
            _state.LoanApplicationDecision = new LoanApplicationDecisionState
            {
                Approved = approved
            };

            return this;
        }
    }
}
