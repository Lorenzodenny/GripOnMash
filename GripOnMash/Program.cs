var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Connessione al DB
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));


// Registro il servizio di Identity, che ci d� la possibilit� di utilizzare tutte le funzionalit� di identity 
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    // Password settings
    options.SignIn.RequireConfirmedEmail = true;
    options.Password.RequireDigit = true;
    options.Password.RequiredLength = 6;
    options.Password.RequireNonAlphanumeric = true;
    options.Password.RequireUppercase = true;
    options.Password.RequireLowercase = false;

    // User settings
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedEmail = true;
    options.SignIn.RequireConfirmedAccount = true;
})
.AddEntityFrameworkStores<ApplicationDbContext>()
.AddDefaultTokenProviders();

// Registro fluent validation
builder.Services.AddFluentValidationAutoValidation()
                .AddFluentValidationClientsideAdapters();

// Registro tutti i validation nell'assembly di program
builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Login/Login";
    options.LogoutPath = "/Logout/Logout";
});

// Registro lo schema dei cookie
builder.Services.AddAuthentication(options =>
{
    // schema predefinito per Identity
    options.DefaultScheme = IdentityConstants.ApplicationScheme;
})
.AddCookie("CookieAuth", options =>
{
    options.LoginPath = "/Login/Login";
    options.LogoutPath = "/Logout/Logout";
    options.Cookie.Name = "auth_cookie_grip_on_mash";
    options.ExpireTimeSpan = TimeSpan.FromHours(1);
    options.SlidingExpiration = true;
});

// Registro il servizio LDAP e le configurazioni
builder.Services.AddSingleton<LdapConfig>();
builder.Services.AddScoped<LoginService>();

// Registro il servizio per invio delle email
builder.Services.AddTransient<EmailService>();

// Registro l'EmailHelper
builder.Services.AddScoped<EmailHelper>();
//builder.Services.AddTransient<EmailService>();

// Configura Data Protection per criptare i cookie
builder.Services.AddDataProtection();
builder.Services.AddScoped<CookieCrypt>();

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
    pattern: "{controller=Login}/{action=Login}");

app.Run();
