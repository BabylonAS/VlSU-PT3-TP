using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Запрос на предоставление расходного материала</summary>
     */
    public class ProvisionRequest: BaseRequest
    {
        [Required]
        [Display(Name = "Разновидность (модель)", ShortName = "Модель")]
        public required ConsumableModel Model { get; set; }
        public uint ModelID { get; set; }

        [Required]
        [Display(Name = "Количество")]
        public required uint Amount { get; set; }

        [Required]
        [Display(Name = "Для устройства")]
        public required Device Device { get; set; }
        public uint DeviceID { get; set; }
    }
}
