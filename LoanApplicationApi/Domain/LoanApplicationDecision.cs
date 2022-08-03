using LoanApplicationAPI.Domain.State;

namespace LoanApplicationAPI.Domain
{
    public class LoanApplicationDecision
    {
        private readonly LoanApplicationDecisionState _state;

        public bool Approved => _state.Approved;

        public static implicit operator LoanApplicationDecisionState(LoanApplicationDecision loanApplicationDecision) => loanApplicationDecision._state;

        public LoanApplicationDecision(LoanApplicationDecisionState state)
        {
            _state = state;
        }

        public LoanApplicationDecision(bool approved)
        {
            _state = new LoanApplicationDecisionState
            {
                Approved = approved
            };
        }
    }
}
