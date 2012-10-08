using System;
using System.Collections.Generic;
using System.Linq;
using MilkPlant.EntityBackend.Infrastructure;
using MilkPlant.Interfaces.Models;
using MilkPlant.Shared;

namespace MilkPlant.EntityBackend
{
    public class SalesAnalytics
    {
        /// <summary>
        /// Plan period in days.
        /// </summary>
        private const int PERIOD = 10;

        private readonly DataContext context;

        public SalesAnalytics(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<Need> GetCurrentNeeds()
        {
            var today = Clock.Now.Date;
            var begin = today.Subtract(TimeSpan.FromDays(PERIOD));

            return from item in context.WarehouseOperations
                       .Where(operation => begin <= operation.Timestamp && operation.Timestamp <= today)
                       .GroupBy(operation => operation.Distributor)
                       .Select(operations =>
                               new
                               {
                                   Distributor = operations.Key,
                                   Products = operations.GroupBy(operation => operation.Product)
                                   .Select(grouping =>
                                           new
                                           {
                                               Product = grouping.Key,
                                               Rate = grouping.Sum(
                                                   operation => operation.Type == WarehouseOperationType.Sold
                                                                    ? operation.Quantity
                                                                    : 0)/PERIOD,
                                               Stock = grouping.Sum(
                                                   operation => operation.Type == WarehouseOperationType.Delivered
                                                                    ? operation.Quantity
                                                                    : -operation.Quantity)
                                           })
                               })
                   from product in item.Products
                   select new Need
                          {
                              Distributor = item.Distributor,
                              Product = product.Product,
                              Quantity = product.Rate*PERIOD - product.Stock
                          };
        }
    }
}