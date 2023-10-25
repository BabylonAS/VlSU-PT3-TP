using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace VlSU_PT3_TP.Infrastructure.Identity
{
    /**
     * <summary>Контект данных для хранения данных о пользователях программной системы</summary>
     */
    public class ApplicationDbContext: IdentityDbContext<ApplicationUser, IdentityRole<Guid>, Guid>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { }
    }
}
