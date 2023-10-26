using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Запрос на выполнение действия над экземплярами расходных материалов</summary>
     */
    public class ActionRequest: BaseRequest
    {
        private ICollection<Consumable>? _consumables;

        [Required]
        [Display(Name = "Расходные материалы")]
        public ICollection<Consumable> Consumables => _consumables ??= new HashSet<Consumable>();

        [Required]
        [Display(Name = "Тип запроса")]
        public required ActionRequestType Type { get; set; }
    }

    /**
     * <summary>Вид действия, запрашиваемого для конкретных экземпляров расходных материалов</summary>
     */
    public enum ActionRequestType
    {
        Return,
        Repair,
        Decommission
    }
}
