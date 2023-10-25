using Microsoft.AspNetCore.Identity;

namespace VlSU_PT3_TP.Infrastructure.Identity
{
    /**
     * <summary>Пользователь программной системы</summary>
     */
    public class ApplicationUser: IdentityUser<Guid>
    {
        /**
         * <summary>Имя</summary>
         */
        public required string FirstName { get; set; }

        /**
         * <summary>Фамилия</summary>
         */
        public required string LastName { get; set; }


        /**
         * <summary>Отчество</summary>
         */
        public string MidName { get; set; } = string.Empty;

        /**
         * <summary>Полное имя в формате «Фамилия, Имя [Отчество]»</summary>
         */
        public string FullName {
            get {
                string fname = $"{LastName}, {FirstName}";
                if (MidName != string.Empty)
                    fname += ' ' + MidName;
                return fname;
            }
        }
    }
}
