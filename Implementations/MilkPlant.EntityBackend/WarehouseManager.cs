using MilkPlant.EntityBackend.Infrastructure;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class WarehouseManager : IWarehouseManager
    {
        private readonly DataContext context;

        public WarehouseManager(DataContext context)
        {
            this.context = context;
        }

        public void RegisterOperation(WarehouseOperation operation)
        {
            context.WarehouseOperations.Add(operation);
            context.SaveChanges();
        }
    }
}