using Microsoft.EntityFrameworkCore;

using VlSU_PT3_TP.Core.Entities;

namespace VlSU_PT3_TP.Infrastructure.Data
{
    /**
     * <summary>Контект данных для бизнес-объектов программной системы</summary>
     */
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

        // Наборы данных
        public DbSet<Consumable> Consumables { get; set; }
        public DbSet<ConsumableModel> ConsumableModels { get; set; }
        public DbSet<ConsumableCategory> ConsumableCategories { get; set; }
        public DbSet<ConsumableStateChange> ConsumableStateChanges { get; set; }
        public DbSet<Device> Devices { get; set; }
        public DbSet<DeviceModel> DeviceModels { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<BaseRequest> Requests { get; set; }
        public DbSet<ProvisionRequest> ProvisionRequests { get; set; }
        public DbSet<ActionRequest> ActionRequests { get; set; }
        public DbSet<RequestStateChange> RequestStateChanges { get; set; }
    }
}
