using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    public class ConsumableModel
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
        public string Type {  get; set; } = string.Empty;

        [Display(Name = "Краткое описание")]
        public string Description { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Ремонтоспособна")]
        public bool Repairable { get; set; } = true;

        [Required]
        [Display(Name = "Скрыта")]
        public bool Hidden { get; set; } = false;

        // Список совместимых технических устройств
        private ICollection<DeviceModel>? _compatibleDevices;
        public ICollection<DeviceModel> CompatibleDevices => _compatibleDevices ??= new HashSet<DeviceModel>();

        // Список категорий, в которые входит модель
        private ICollection<ConsumableCategory>? _categories;
        public ICollection<ConsumableCategory> Categories => _categories ??= new HashSet<ConsumableCategory>();

    }
}
