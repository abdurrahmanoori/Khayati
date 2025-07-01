using FluentValidation;
using Newtonsoft.Json;

public class ExceptionMiddleware
{
    private readonly RequestDelegate _next;

    public ExceptionMiddleware(RequestDelegate next)
    {
        _next = next;
    }

    public async Task InvokeAsync(HttpContext context)
    {
        try
        {
            await _next(context);
        }
        catch (Exception ex)
        {
            await HandleExceptionAsync(context, ex);
        }
    }

    private Task HandleExceptionAsync(HttpContext context, Exception exception)
    {
        context.Response.ContentType = "application/json";

        if (exception is ValidationException validationException)
        {
            context.Response.StatusCode = StatusCodes.Status400BadRequest;

            var errors = validationException.Errors
                .Select(error => new { error.PropertyName, error.ErrorMessage });

            var result = JsonConvert.SerializeObject(new
            {
                StatusCode = context.Response.StatusCode,
                Errors = errors
            });

            return context.Response.WriteAsync(result);
        }

        // Handle other exceptions (optional)
        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
        return context.Response.WriteAsync(JsonConvert.SerializeObject(new
        {
            StatusCode = context.Response.StatusCode,
            Message = "Internal Server Error"
        }));
    }
}
