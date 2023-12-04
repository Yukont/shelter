using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.EFUnitOfWork;
using Microsoft.AspNetCore.Authentication.Cookies;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
        .AddCookie(options =>
        {
            options.LoginPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
            options.AccessDeniedPath = new Microsoft.AspNetCore.Http.PathString("/Account/Login");
        });

builder.Services.AddAutoMapper(typeof(BLL.Mapping.AdoptionStatusMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.AdoptionStatusMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.AuthMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.AuthMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.UsersGenderMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.UsersGenderMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.UserMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.AnimalStatusMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.AnimalStatusMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.ClinicMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.ClinicMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.SpeciesMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.SpeciesMapper));
builder.Services.AddAutoMapper(typeof(BLL.Mapping.GenderMapper));
builder.Services.AddAutoMapper(typeof(shelter.Mapping.GenderMapper));

builder.Services.AddScoped<IAdoptionStatusService, AdoptionStatusService>();
builder.Services.AddScoped<IUserGenderService, UserGenderService>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IAnimalStatusService, AnimalStatusService>();
builder.Services.AddScoped<IClinicService, ClinicService>();
builder.Services.AddScoped<ISpeciesService, SpeciesService>();
builder.Services.AddScoped<IGenderService, GenderService>();

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

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
