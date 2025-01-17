using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MvcCleanArch.Infrastructure.Persistence.DbContext;
using MvcCleanArch.Domain.Models;
using MvcCleanArch.Application.Mappers;
using MvcCleanArch.Domain.Interfaces;
using MvcCleanArch.Infrastructure.Persistence.Repositories;
using MvcCleanArch.Application.Services;
using MvcCleanArch.Application.Services.ServiceContracts;
using MvcCleanArch.Domain.Services.ServiceContracts;
using MvcCleanArch.Domain.Services;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddIdentity<AppUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.Password.RequireDigit = false; // No numeric characters required
    options.Password.RequireLowercase = false; // No lowercase letters required
    options.Password.RequireUppercase = false; // No uppercase letters required
    options.Password.RequireNonAlphanumeric = false; // No special characters required
    options.Password.RequiredLength = 1; // Minimum length of 1
    options.Password.RequiredUniqueChars = 0; // No unique characters required
})
    .AddEntityFrameworkStores<ApplicationDbContext>().
    AddDefaultUI()
    .AddDefaultTokenProviders();

builder.Services.AddAutoMapper(typeof(MappingProfile));

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
builder.Services.AddScoped<IMovieUserRepository, MovieUserRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

builder.Services.AddScoped<IGenreService, GenreService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieUserDomainService, MovieUserDomainService>();



builder.Services.AddControllersWithViews()
            .AddRazorOptions(options =>
            {
                options.ViewLocationFormats.Clear();
                options.ViewLocationFormats.Add("/Presentation/Views/{1}/{0}.cshtml");
                options.ViewLocationFormats.Add("/Presentation/Views/Shared/{0}.cshtml");
            });

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
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
app.MapRazorPages();

app.Run();
