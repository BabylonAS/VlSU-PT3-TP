using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Категория расходных материалов</summary>
     */
    public class ConsumableCategory
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Display(Name = "Описание")]
        public string Description { get; set; } = string.Empty;

        // Входящие модели
        private ICollection<ConsumableModel>? _models;
        public ICollection<ConsumableModel> Models => _models ??= new HashSet<ConsumableModel>();
    }
}
