using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Изменение состояния запроса</summary>
     */
    public class RequestStateChange
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Required]
        [Display(Name = "Запрос")]
        public required BaseRequest Request { get; set; }
        public uint RequestID { get; set; }

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
        public required RequestState Old { get; set; }

        [Required]
        [Display(Name = "Новое состояние")]
        public required RequestState New { get; set; }
    }
}
