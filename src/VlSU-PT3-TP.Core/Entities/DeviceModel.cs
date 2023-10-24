using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    public class DeviceModel
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Required]
        [Display(Name = "Обозначение")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Производитель")]
        public string Manufacturer { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Тип")]
        public string Type { get; set; } = string.Empty;

        // Совместимые модели расходных материалов
        private ICollection<ConsumableModel>? _compatibleConsumables;
        public ICollection<ConsumableModel> CompatibleConsumables => _compatibleConsumables ??= new HashSet<ConsumableModel>();

        // Относящиеся к модели устройства
        private ICollection<Device>? _devices;
        public ICollection<Device>? Devices => _devices ??= new HashSet<Device>();
    }
}
