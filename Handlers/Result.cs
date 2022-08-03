namespace LoanApplicationAPI.Handlers
{
    public class Result<TResult> where TResult : class
    {
        public TResult? Value { get; }
        public bool IsSuccess { get; }
        public string? ErrorMessage { get; }

        Result(bool success, TResult? value = null, string? errorMessage = null)
        {
            IsSuccess = success;
            ErrorMessage = errorMessage;
            Value = value;
        }

        public static Result<TResult> Success(TResult value)
        {
            return new Result<TResult>(true, value);
        }

        public static Result<TResult> Error(string error)
        {
            return new Result<TResult>(false, errorMessage: error);
        }
    }
}
