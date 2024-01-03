using Core.Failures;

namespace Core.Result
{
    public class Result<T>
    {
        public bool IsSuccess { get; }
        public bool IsFailure => !IsSuccess;
        public Failure Error { get; }
        public T Value { get; }
        private Result(T value)
        {
            this.IsSuccess = true;
            this.Value = value;
        }
        private Result(Failure Failure)
        {
            this.IsSuccess = false;
            this.Error = Failure;
        }
        public static Result<T> Success(T value) => new(value);

        public static Result<T> Failure(Failure Failure) => new(Failure);

    }
}
