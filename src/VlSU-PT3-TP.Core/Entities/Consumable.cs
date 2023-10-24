using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    public class Consumable
    {
        [Key]
        [Display(Name = "Инвентарный номер", ShortName = "№")]
        public uint InventoryNumber { get; set; }

        // идентификатор модели
        public uint ModelID { get; set; }

        [Required]
        [Display(Name = "Разновидность (модель)", ShortName = "Модель")]
        public required ConsumableModel Model { get; set; }

        // идентификатор технического устройства
        public uint? DeviceID { get; set; }

        [Display(Name = "Техническое устройство", ShortName = "Устройство")]
        public Device? Device { get; set; }

        [Required]
        [Display(Name = "Дата производства")]
        public DateTime ManufacturyDate { get; set; }

        [Display(Name = "Срок годности")]
        public TimeSpan? ExpiryDate { get; set; }

        [Required]
        [Display(Name = "Состояние")]
        public required ConsumableState State { get; set; }
    }

    public enum ConsumableState
    {
        Free,
        Reserved,
        InUse,
        NeedsRepair,
        Decommisioned
    }
}
