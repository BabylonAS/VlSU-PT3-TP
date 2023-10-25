using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Экземпляр технического устройства</summary>
     */
    public class Device
    {
        [Key]
        [Display(Name = "Инвентарный номер", ShortName = "№")]
        public uint InventoryNumber { get; set; }

        // идентификатор модели
        public uint ModelID { get; set; }

        [Required]
        [Display(Name = "Модель")]
        public required DeviceModel Model { get; set; }

        // идентификатор подразделения
        public uint? DepartmentID { get; set; }

        [Display(Name = "Подразделение")]
        public Department? Department { get; set; }

        // Закреплённые расходные материалы
        private ICollection<Consumable>? _attachedConsumables;
        public ICollection<Consumable>? AttachedConsumables => _attachedConsumables ??= new HashSet<Consumable>();
    }
}
