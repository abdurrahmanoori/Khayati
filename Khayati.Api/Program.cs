using FluentValidation;
using FluentValidation.AspNetCore;
using Khayati.Core.DTO.Embellishments.Validatores;
using Khayati.Core.Extention;
using Khayati.Infrastructure.Extension;
//using Khayati.Mvc.Extenstion;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers()
    .AddControllersAsServices();

builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<EmbellishmentResponseDetailsDtoValidator>();// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();




builder.Services.AddSwaggerGen();


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
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
