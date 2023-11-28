using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.EFUnitOfWork;
using DAL.EF;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAutoMapper(typeof(BLL.Mapping.AdoptionStatusMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.AdoptionStatusMapper));

builder.Services.AddScoped<IAdoptionStatusService, AdoptionStatusService>();
builder.Services.AddScoped<IUnitOfWork, EFUnitOfWork>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
