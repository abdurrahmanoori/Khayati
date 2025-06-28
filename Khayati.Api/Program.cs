using FluentValidation;
using FluentValidation.AspNetCore;
using Khayati.Core.Common.Response;
using Khayati.Core.Extention;
using Khayati.Infrastructure.Extension;
using Microsoft.AspNetCore.Mvc;
//using static Khayati.Core.Common.Response.Result<Program>;
//using Khayati.Mvc.Extenstion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddControllersAsServices();


builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var errors = context.ModelState
            .Where(e => e.Value?.Errors.Count > 0)
            .Select(e => new
            {
                Field = e.Key,
                Messages = e.Value?.Errors.Select(x => x.ErrorMessage).ToList()
            })
            .ToList();

        var validationErrors = new List<ValidationError>();

        foreach (var error in errors)
        {
            foreach (var message in error?.Messages)
            {
                validationErrors.Add(new ValidationError
                {
                    Code = "ValidationError",
                    Property = error.Field,
                    Description = message
                });
            }
        }

        return new BadRequestObjectResult(validationErrors);
    };

});

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddHttpClient("ApiClient", client =>
{
    client.BaseAddress = new Uri("https://localhost:7016");
});


builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        policy => policy
            .WithOrigins("http://localhost:3011")
            .AllowAnyMethod()
            .AllowAnyHeader());
});

builder.Services.ConfigureApplicationService(builder.Configuration);
builder.Services.ConfigureInfrastructureService();
//builder.Services.ConfigurePresentionService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // app.UseMiddleware<ExceptionMiddleware>();
}
app.UseCors("AllowReactApp");
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
