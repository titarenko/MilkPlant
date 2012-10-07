using System.Data.Entity;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend.Infrastructure
{
    public class DataContext : DbContext
    {
        public virtual IDbSet<Product> Products { get; set; }

        public virtual IDbSet<Distributor> Distributors { get; set; }

        public virtual IDbSet<Truck> Trucks { get; set; }

        public virtual IDbSet<DeliveryPlan> DeliveryPlans { get; set; }

        public virtual IDbSet<WarehouseOperation> WarehouseOperations { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<DataContext, MigrationConfiguration>());
            base.OnModelCreating(modelBuilder);
        }
    }
}