using System.ComponentModel.DataAnnotations;

namespace VlSU_PT3_TP.Core.Entities
{
    /**
     * <summary>Структурное подразделение предприятия</summary>
     */
    public class Department
    {
        [Key]
        [Display(Name = "Идентификатор", ShortName = "№")]
        public uint ID { get; set; }

        [Required]
        [Display(Name = "Название")]
        public required string Name { get; set; }

        [Display(Name = "Краткое описание")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Начальник подразделения", ShortName = "Начальник")]
        public Guid Head { get; set; } = Guid.Empty;

        // Устройства
        private ICollection<Device>? _devices;
        public ICollection<Device> Devices => _devices ??= new HashSet<Device>();
    }
}
