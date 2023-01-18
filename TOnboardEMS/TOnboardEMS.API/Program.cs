using Microsoft.EntityFrameworkCore;
using TOnboardEMS.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<OnboardContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("OnboardDatabase")));
builder.Services.AddControllers();
var app = builder.Build();


// Configure the HTTP request pipeline.

app.UseHttpsRedirection();
app.UseRouting();

app.MapGet("/api/Access/", () =>"Hello World");
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
