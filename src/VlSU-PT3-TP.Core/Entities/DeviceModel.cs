using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Модель технического устройства</summary>
     */
    public class DeviceModel
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Required]
        [Display(Name = "Обозначение")]
        public required string Name { get; set; }

        [Required]
        [Display(Name = "Производитель")]
        public required string Manufacturer { get; set; }

        [Required]
        [Display(Name = "Тип")]
        public required string Type { get; set; }

        [Display(Name = "Краткое описание")]
        public string Description { get; set; } = string.Empty;

        // Совместимые модели расходных материалов
        private ICollection<ConsumableModel>? _compatibleConsumables;
        public ICollection<ConsumableModel> CompatibleConsumables => _compatibleConsumables ??= new HashSet<ConsumableModel>();

        // Относящиеся к модели устройства
        private ICollection<Device>? _devices;
        public ICollection<Device>? Devices => _devices ??= new HashSet<Device>();
    }
}
