using System.Data.Entity;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class DataContext : DbContext
    {
        public IDbSet<Product> Products { get; set; }

        public IDbSet<Distributor> Distributors { get; set; }

        public IDbSet<SoldItem> SoldItems { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer(new CreateDatabaseIfNotExists<DataContext>());
            base.OnModelCreating(modelBuilder);
        }
    }
}