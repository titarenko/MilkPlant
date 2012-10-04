using MilkPlant.Interfaces.Models;

namespace MilkPlant.Interfaces
{
    public interface IReferenceDataManager
    {
        void AddProduct(Product product);
        void AddDistributor(Distributor distributor);
        void AddTruck(Truck truck);
    }
}