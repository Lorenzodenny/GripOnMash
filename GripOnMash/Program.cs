using FluentValidation;
using FluentValidation.AspNetCore;
using GripOnMash.FluentValidator;
using GripOnMash.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connessione al DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registro il servizio di Identity, che ci dà la possibilità di utilizzare tutte le funzionalità di identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.SignIn.RequireConfirmedEmail = true; 
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Registro fluent validation
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

// Registro tutti i validation nell'assembly di program
builder.Services.AddValidatorsFromAssemblyContaining<Program>();



// Registro lo schema dei cookie
builder.Services.AddAuthentication(options =>
{
    // schema predefinito per Identity
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Auth/Login";
    options.Cookie.Name = "auth_cookie_grip_on_mash";
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.SlidingExpiration = true;
});

// Registro il servizio LDAP e le configurazioni
builder.Services.AddSingleton<LdapConfig>();
builder.Services.AddScoped<LoginService>();

// Registro il servizio per invio delle email
builder.Services.AddTransient<EmailService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
