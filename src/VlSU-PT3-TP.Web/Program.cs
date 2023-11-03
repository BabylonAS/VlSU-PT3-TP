// VlSU-PT3-TP.Web.Program

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using VlSU_PT3_TP.Infrastructure.Data;
using VlSU_PT3_TP.Infrastructure.Identity;

// Сборщик веб-приложения
var builder = WebApplication.CreateBuilder(args);

// Добавление поддержки баз данных Microsoft SQL Server
builder.Services.AddDbContext<AppIdentityDbContext>(options =>
{
    var connectionString = builder.Configuration["VLSU_PT3_TP_IDENTITY_DB_CONNECTION_STRING"] ?? "";
    options.UseSqlServer(connectionString);
});
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration["VLSU_PT3_TP_MAIN_DB_CONNECTION_STRING"] ?? "";
    options.UseSqlServer(connectionString);
});

// Добавление поддержки ASP.NET Core Identity
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();

// Настройки куки
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true; // нужно согласие
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

// Собрать приложение
var app = builder.Build();

// Инициализировать базу данных
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;

    try
    {
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        identityContext.Database.EnsureCreated();

        var context = services.GetRequiredService<ApplicationDbContext>();
        context.Database.EnsureCreated();
    }
    catch (Exception ex)
    {
        var logger = services.GetRequiredService<ILogger<Program>>();
        logger.LogError(ex, "Не удалось создать базы данных для первого использования! {exceptionMessage}", ex.Message);
    }
}

// Перенаправление с обычного HTTP на HTTPS
app.UseHttpsRedirection();

// Применить параметры аутентификации и авторизации
app.UseCookiePolicy();
app.UseAuthentication();
app.UseAuthorization();

app.MapGet("/", () => "Coming soon");

// Запуск приложения
app.Run();
