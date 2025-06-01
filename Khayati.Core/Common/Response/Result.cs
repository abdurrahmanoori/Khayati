using System.ComponentModel.DataAnnotations;

namespace Khayati.Core.Common.Response
{

    public class Result
    {
        public long Id { get; set; }

        public bool Success { get; set; } = true;

        public string? Message { get; set; }

        public List<string>? Errors { get; set; }
        public List<ValidationError>? Errorssss { get; set; }

    }

    public class Result<T>
    {
        public long Id { get; set; }

        public T? Response { get; set; }

        public bool Success { get; set; } = true;

        public string? Message { get; set; }

        public List<ValidationError>? Errors { get; set; }

        public static Result<T> SuccessResult(T? result)
        {
            return new Result<T>
            {
                Success = true,
                Response = result,
            };
        }

        // This method is written by Abdurrahman

        /// <summary>
        /// Creates a successful command response with the provided result and validation error details.
        /// </summary>
        /// <typeparam name="T">The type of the result.</typeparam>
        /// <param name="result">The result to include in the response.</param>
        /// <param name="validationError">The validation error containing description details.</param>
        /// <returns>A <see cref="Result{T}"/> indicating success and containing the result and message.</returns>
        public static Result<T> SuccessResult(T? result, ValidationError validationError)
        {
            return new Result<T>
            {
                Success = true,
                Response = result,
                Message = validationError.Description.ToString(),
            };
        }

        public static Result<T> NotFoundResult( )
        {
            return new Result<T>
            {
                Success = false,
            };
        }

        public static Result<T> FailureResult(string code, string description)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new List<ValidationError>
        {
            new ValidationError { Code = code, Description = description }
        },
            };
        }

        public static Result<T> WithError(ValidationError error)
        {
            return new Result<T>
            {
                Success = false,
                Errors = new List<ValidationError> { error },
            };
        }

        public static class test
        {

         public static Result WithErrorrr(ValidationError error)
            {
                return new Result
                {
                    Success = false,
                    Errorssss = new List<ValidationError> { error },
                };
            }
        }

        public static Result<T> WithErrors(List<ValidationError> errors)
        {
            return new Result<T>
            {
                Success = false,
                Errors = errors,
            };
        }

        //public static bool HasErrors<T>(AbstractValidator<T> validator, T dto, out List<ValidationError> errors)
        //{
        //    var result = validator.Validate(dto);
        //    errors = new List<ValidationError>();  // Initialize with new List
        //    if (result.Errors.Any())
        //    {
        //        errors.AddRange(result.Errors.Select(x => new ValidationError
        //        {
        //            Code = x.ErrorCode,
        //            Description = x.ErrorMessage,
        //            Property = x.PropertyName,
        //        }));
        //        return true;
        //    }
        //    return false;
        //}

        //public static bool HasErrors(ValidationResult validation, out List<ValidationError> errors)
        //{
        //    errors = new List<ValidationError>();  // Initialize with new List
        //    if (validation.Errors.Any())
        //    {
        //        errors.AddRange(validation.Errors.Select(x => new ValidationError
        //        {
        //            Code = x.ErrorCode,
        //            Description = x.ErrorMessage,
        //            Property = x.PropertyName,
        //        }));
        //        return true;
        //    }
        //    return false;
        //}

    }

    public class ValidationError
    {
        public override string ToString( )
        {
            return $"Code: {this.Code}, Property: {this.Property}, Description: {this.Description}";
        }

        public string? Code { get; set; }

        public string? Property { get; set; }

        public string? Description { get; set; }
        public List<string>? Descriptions { get; set; }
    }

}
