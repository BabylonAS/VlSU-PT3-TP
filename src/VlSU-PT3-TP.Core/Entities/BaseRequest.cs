using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Запрос, касающийся расходных материалов</summary>
     */
    public abstract class BaseRequest
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public int ID { get; set; }

        [Required]
        [Display(Name = "Дата подачи")]
        public DateTime Date { get; set; }

        [Required]
        [Display(Name = "Кем подан")]
        public required Guid SentBy { get; set; }

        [Display(Name = "Кем рассмотрен")]
        public Guid ReviewedBy { get; set; } = Guid.Empty;

        [Required]
        [Display(Name = "Состояние")]
        public required RequestState State { get; set; }
    }

    /**
     * <summary>Состояние, в котором может пребывать запрос</summary>
     */
    public enum RequestState
    {
        NotReviewed,
        Accepted,
        Cancelled,
        Rejected
    }
}
