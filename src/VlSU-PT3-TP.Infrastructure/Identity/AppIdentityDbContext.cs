using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VlSU_PT3_TP.Infrastructure.Identity
{
    /**
     * <summary>Контект данных для подсистемы идентификации пользователей</summary>
     */
    public class AppIdentityDbContext: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public AppIdentityDbContext(DbContextOptions<AppIdentityDbContext> options): base(options) { }
    }
}
