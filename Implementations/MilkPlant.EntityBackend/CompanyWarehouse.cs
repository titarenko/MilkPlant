using System.Collections.Generic;
using System.Linq;
using MilkPlant.EntityBackend.Infrastructure;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class CompanyWarehouse
    {
        private readonly IDictionary<Product, double> available;

        public CompanyWarehouse(DataContext context)
        {
            available = context.WarehouseOperations
                .Where(x => x.Distributor == null)
                .GroupBy(x => x.Product)
                .ToDictionary(
                    operations => operations.Key,
                    operations => operations.Sum(
                        operation => operation.Type == WarehouseOperationType.Produced
                                         ? operation.Quantity
                                         : -operation.Quantity));
        }

        public double GetAvailableItemsCount(Product product)
        {
            return available.ContainsKey(product) ? available[product] : 0;
        }

        public void Consume(Product product, double quantity)
        {
            if (available.ContainsKey(product))
            {
                if (available[product] < quantity)
                {
                    throw new OutOfStockException();
                }

                available[product] -= quantity;
            }

            throw new OutOfStockException();
        }
    }
}