using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ProjetoASPNetCore.Data;
using ProjetoASPNetCore.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ProjetoASPNetCoreContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ProjetoASPNetCoreContext"), builder => builder.MigrationsAssembly("ProjetoASPNetCore")));

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<SeedingService>();

builder.Services.AddScoped<SellerService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.Services.CreateScope().ServiceProvider.GetRequiredService<SeedingService>().Seed();

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
