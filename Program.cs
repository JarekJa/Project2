using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Project2.DataBase;
using Project2.Models.Users;
using Project2.Services;
using Project2.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IFirstInitialization, FirstInitialization>();
builder.Services.AddScoped<IUserUpdater, UserUpdater>();
builder.Services.AddScoped<IAccountService, AccountService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddControllersWithViews();


var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseMySql(connectionString,ServerVersion.AutoDetect(connectionString));
});
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequiredLength = 2; 
    options.Password.RequireDigit = false; 
    options.Password.RequireLowercase = false; 
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;
    options.SignIn.RequireConfirmedAccount = false;
})
    .AddEntityFrameworkStores<MyDbContext>()
    .AddDefaultTokenProviders();
builder.Services.ConfigureApplicationCookie(options =>
{
    options.ExpireTimeSpan = TimeSpan.FromMinutes(20); 
    options.SlidingExpiration = true;
    options.Cookie.MaxAge = null;
    options.Cookie.HttpOnly = true;
    options.Cookie.SecurePolicy = CookieSecurePolicy.Always;
    options.Cookie.SameSite = SameSiteMode.Lax;
    options.Cookie.IsEssential = true;
    options.Cookie.Expiration = null; 
});
builder.Services.AddHttpContextAccessor();
var app = builder.Build();
using (var scope = app.Services.CreateScope())
{
    var serviceProvider = scope.ServiceProvider;

    try
    {
        var roleInitializer = serviceProvider.GetRequiredService<IFirstInitialization>();
        await roleInitializer.InitializeRolesAsync();
        await roleInitializer.InitializeAdminAsync();
        await roleInitializer.InitializeBossAsync();
    }
    catch (Exception ex)
    {
        var logger = serviceProvider.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Error initializing data");
    }
}
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
