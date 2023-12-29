// VlSU-PT3-TP.Web.Program

using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

using VlSU_PT3_TP.Infrastructure.Data;
using VlSU_PT3_TP.Infrastructure.Identity;

// Сборщик веб-приложения
var builder = WebApplication.CreateBuilder(args);

// Ведение журнала в консоли
builder.Logging.AddConsole();

// Добавление поддержки баз данных Microsoft SQL Server
builder.Services.AddDbContext<AppIdentityDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Identity") ?? "")
);
builder.Services.AddDbContext<ApplicationDbContext>(
    options => options.UseSqlServer(builder.Configuration.GetConnectionString("Main") ?? "")
);

// Добавление поддержки системы удостоверения пользователей ASP.NET Core Identity
/*
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<AppIdentityDbContext>()
    .AddDefaultTokenProviders();
*/

// Настройки куки
builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true; // нужно согласие
    options.MinimumSameSitePolicy = SameSiteMode.None;
});

builder.Services.AddRazorPages();

// Собрать приложение
var app = builder.Build();

// Инициализировать базы данных и роли пользователей
using (var scope = app.Services.CreateScope())
{
    // Поставщик служб
    var services = scope.ServiceProvider;

    // Журнальная служба
    var logger = services.GetRequiredService<ILogger<Program>>();

    try
    {
        // Удостоверяемся, что базы данных созданы
        var identityContext = services.GetRequiredService<AppIdentityDbContext>();
        if (identityContext.Database.EnsureCreated())
            logger.LogInformation("Создана БД учётных записей");
        var context = services.GetRequiredService<ApplicationDbContext>();
        if (context.Database.EnsureCreated())
            logger.LogInformation("Создана основная БД");

        /*
        // Удостоверяемся, что роли созданы, с использованием вспомогательной функции
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();

        var adminRoleTask = EnsureRoleAddedAsync(roleManager, "Администратор", logger);
        var depManagerRoleTask = EnsureRoleAddedAsync(roleManager, "Начальник подразделения", logger);
        var accountantRoleTask = EnsureRoleAddedAsync(roleManager, "Учётчик", logger);
        Task.WaitAll(adminRoleTask, depManagerRoleTask, accountantRoleTask);
        */
    }
    catch (Exception ex)
    {
        logger.LogError(ex, "Ошибка на этапе инициализации данных! {exceptionMessage}", ex.Message);
    }

}

// Перенаправление с обычного HTTP на HTTPS
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

// Применить параметры куки, аутентификации и авторизации
app.UseCookiePolicy();
//app.UseAuthentication();
//app.UseAuthorization();

app.MapRazorPages();

// Запуск приложения
app.Run();

// Вспомогательная функция для добавления роли
static async Task EnsureRoleAddedAsync(RoleManager<IdentityRole> roleManager, string roleName, ILogger logger)
{
    if (!await roleManager.RoleExistsAsync(roleName))
    {
        var result = await roleManager.CreateAsync(new IdentityRole(roleName));
        if (result.Succeeded)
            logger.LogInformation("Создана роль «{RoleName}»", roleName);
        else
            logger.LogError("Не удалось создать роль «{RoleName}»: {identityErrors}", roleName, string.Join(", ", result.Errors));
    }
}