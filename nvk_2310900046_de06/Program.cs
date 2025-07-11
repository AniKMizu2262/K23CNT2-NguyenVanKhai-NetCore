using Microsoft.EntityFrameworkCore;
using nvk_2310900046_de06.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Add DbContext with connection string from appsettings.json
var connectionString = builder.Configuration.GetConnectionString("NvkDbConnect");
builder.Services.AddDbContext<NguyenVanKhai2310900046De06Context>(options =>
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/NvkHome/NvkError");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NvkHome}/{action=NvkIndex}/{nvkID?}");

app.Run();