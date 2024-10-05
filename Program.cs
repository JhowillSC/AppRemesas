using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using AppRemesas.Data;
using AppRemesas.Services; // Asegúrate de agregar este espacio de nombres

var builder = WebApplication.CreateBuilder(args);

// Configuración de conexión a PostgreSQL
var connectionString = builder.Configuration.GetConnectionString("PosgreConnection") 
    ?? throw new InvalidOperationException("Connection string 'PosgreConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseNpgsql(connectionString));

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<ApplicationDbContext>();

// Registrar el servicio para la conversión de moneda
builder.Services.AddHttpClient<CurrencyConversionService>();

builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
