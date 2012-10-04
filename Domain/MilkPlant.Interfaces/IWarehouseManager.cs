using MilkPlant.Interfaces.Models;

namespace MilkPlant.Interfaces
{
    public interface IWarehouseManager
    {
        void RegisterOperation(WarehouseOperation operation);
    }
}