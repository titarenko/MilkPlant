using MilkPlant.EntityBackend.Infrastructure;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class ReferenceDataManager : IReferenceDataManager
    {
        private readonly DataContext context;

        public ReferenceDataManager(DataContext context)
        {
            this.context = context;
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public void AddDistributor(Distributor distributor)
        {
            context.Distributors.Add(distributor);
            context.SaveChanges();
        }

        public void AddTruck(Truck truck)
        {
            context.Trucks.Add(truck);
            context.SaveChanges();
        }
    }
}