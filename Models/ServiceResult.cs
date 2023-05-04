namespace Models
{
    public class ServiceResult<T>
    {
        public ServiceResult(T value)
        {
            this.Success = true;
            this.Value = value;
        }

        public ServiceResult(string message)
        {
            this.Success = false;
            this.FailureMessage = message;
            this.Value = default;
        }

        public ServiceResult(Exception ex)
        {
            this.Success = false;
            this.Exception = ex;
            this.Value = default;
        }

        public bool Success { get; set; }

        public string? FailureMessage { get; set; }

        public Exception? Exception { get; set; }

        public bool IsException { get => this.Exception != null; }

        public T? Value { get; set; }

        public static ServiceResult<T> SuccesResult(T value)
        {
            return new ServiceResult<T>(value);
        }

        public static ServiceResult<T> FailureResult(string message)
        {
            return new ServiceResult<T>(message);
        }

        public static ServiceResult<T> ExceptionResult(Exception ex)
        {
            return new ServiceResult<T>(ex);
        }
    }
}
