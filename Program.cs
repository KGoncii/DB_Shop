using DB_Shop.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);

// Konfiguracja połączenia z bazą danych dla aplikacji (DB_ShopContext)
builder.Services.AddDbContext<DB_ShopContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DB_ShopContext")
    ?? throw new InvalidOperationException("Connection string 'DB_ShopContext' not found.")));

// Konfiguracja połączenia z bazą danych dla tożsamości (Identity)
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

// Dodanie wymogu unikalności adresu e-mail podczas rejestracji
builder.Services.AddDefaultIdentity<IdentityUser>(options =>
{
    options.SignIn.RequireConfirmedAccount = true;
    options.User.RequireUniqueEmail = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>();

// Dodanie kontrolerów z widokami
builder.Services.AddControllersWithViews();

var cultureInfo = new System.Globalization.CultureInfo("en-US");
cultureInfo.NumberFormat.CurrencyDecimalSeparator = ".";

CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

var app = builder.Build();

// Konfiguracja potoku HTTP
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Products}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
