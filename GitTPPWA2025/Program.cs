using GitTPPWA2025.Data;
using GitTPPWA2025.ModelsEF;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<MascoTiendaContext>(options =>
options.UseSqlServer(builder.Configuration.GetConnectionString("ConexionSQL"))
);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=ProyectoMascoTienda}/{action=Index}/{id?}");

app.Run();
