//using Khayati.Repositories.Extention;
using Khayati.Core.Extention;
using Khayati.Infrastructure.Extension;
using Khayati.Mvc.Extenstion;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews().AddRazorRuntimeCompilation(); 


//builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
//builder.Services.AddScoped<ICustomerService, CustomerService>();
//builder.Services.AddScoped<IEmbellishmentTypeService, EmbellishmentTypeService>();
//builder.Services.AddScoped<IMeasurementService, MeasurementService>();

//builder.Services.AddScoped<IEmbellishmentService, EmbellishmentService>();

//builder.Services.AddDbContext<ApplicationDbContext>(option =>
//{
//    //    option.UseInMemoryDatabase("server=.;Database=SMSDb;Trusted_Connection=True;TrustServerCertificate=Yes;");
//    option.UseSqlite("Data Source=Khayati.db");
//});





//Add services to the container.
builder.Services.ConfigureInfrastructureService();
builder.Services.ConfigureApplicationService(builder.Configuration);
builder.Services.ConfigurePresentionService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

//Areas Configuration filed...
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
        name: "areas",
        pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");
    endpoints.MapControllerRoute(
        name: "default",
        pattern: "{controller=Home}/{action=Index}/{id?}");
});

//app.MapControllerRoute(
//    name: "default",
//    pattern: "{controller=Home}/{action=Index}/{id?}");




app.Run();
