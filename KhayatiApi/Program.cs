using Entities.Data;
using Khayati.Service;
using Khayati.ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Repositories.Base;
using RepositoryContracts.Base;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICustomerService, CustomerService>();

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    //    option.UseInMemoryDatabase("server=.;Database=SMSDb;Trusted_Connection=True;TrustServerCertificate=Yes;");
    option.UseSqlite("Data Source=Khayati.db");
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
