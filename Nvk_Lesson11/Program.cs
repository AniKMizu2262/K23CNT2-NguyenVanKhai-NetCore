using Microsoft.EntityFrameworkCore;
using Nvk_Lesson11.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

var connectionString = builder.Configuration.GetConnectionString("NvkDbConnect");
builder.Services.AddDbContext<NguyenVanKhai2310900046Context>(x => x.UseSqlServer(connectionString));
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/NvkHome/NvkError");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=NvkHome}/{action=NvkIndex}/{nvkID?}");
app.MapControllerRoute(
    name: "NvkEmployee",
    pattern: "{controller=NvkEmployees}/{action=NvkIndex}/{nvkID?}"
    ); 
app.Run();
