using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Изменение состояния экземпляра расходного материала</summary>
     */
    public class ConsumableStateChange
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Display(Name = "Расходный материал")]
        public required Consumable Consumable { get; set; }
        public uint ConsumableID { get; set; }

        [Required]
        [Display(Name = "Пользователь")]
        public required Guid User { get; set; }

        [Required]
        [Display(Name = "Дата и время изменения")]
        public required DateTime DateTime { get; set; }

        [Display(Name = "Комментарий")]
        public string Comment { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Старое состояние")]
        public required ConsumableState Old { get; set; }

        [Required]
        [Display(Name = "Новое состояние")]
        public required ConsumableState New { get; set; }

        [Display(Name = "Откреплён от")]
        public Device? DetachedFrom { get; set; }
        public uint? DetachedFromID { get; set; }

        [Display(Name = "Закреплён за")]
        public Device? AttachedTo { get; set; }
        public uint? AttachedToID { get; set; }
    }
}
