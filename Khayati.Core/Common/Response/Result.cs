namespace Khayati.Core.Common.Response
{

    public class Result<T>
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public List<ValidationError> ValidationErrors { get; private set; }
        public string ErrorCode { get; private set; }
        public T Data { get; private set; }

        // Constructor for successful responses
        private Result(T data, string message)
        {
            Success = true;
            Message = message ?? "Operation succeeded.";
            Data = data;
            ValidationErrors = null;
            ErrorCode = null;
        }

        // Constructor for failure responses
        private Result(string errorCode, string message, List<ValidationError> validationErrors = null)
        {
            Success = false;
            Message = message ?? "Operation failed.";
            ValidationErrors = validationErrors;
            ErrorCode = errorCode;
            Data = default;
        }

        // Static method to return success result
        public static Result<T> SuccessResult(T data, string message = null)
        {
            return new Result<T>(data, message);
        }

        // Static method to return failure result with errors
        public static Result<T> FailureResult(string errorCode, string message = null, List<ValidationError> validationErrors = null)
        {
            return new Result<T>(errorCode, message, validationErrors);
        }

        // Static method to return failure with default error message and code
        public static Result<T> DefaultError(string message = "An unexpected error occurred.")
        {
            return new Result<T>("ERROR_UNKNOWN", message);
        }

        // Static method for validation failure
        public static Result<T> ValidationFailure(List<ValidationError> validationErrors)
        {
            return new Result<T>("VALIDATION_ERROR", "Validation failed.", validationErrors);
        }

        // Check if it contains validation errors
        public bool HasValidationErrors => ValidationErrors != null && ValidationErrors.Count > 0;
    }

    public class ValidationError
    {
        public string Property { get; set; }
        public string ErrorMessage { get; set; }
    }

}
