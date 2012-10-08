using System;
using System.Collections.Generic;
using MilkPlant.EntityBackend.Infrastructure;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;
using System.Linq;
using MilkPlant.Shared;

namespace MilkPlant.EntityBackend
{
    public class DeliveryManager : IDeliveryManager
    {
        private readonly DataContext context;

        /// <summary>
        /// Plan period in days.
        /// </summary>
        private const int PERIOD = 10;

        public DeliveryManager(DataContext context)
        {
            this.context = context;
        }

        public IEnumerable<DeliveryPlan> GetDeliveryPlan(DateTime date)
        {
            var needs = GetNeeds().OrderByDescending(x => x.Quantity).ToList();
            var availabilities = GetAvailabilities().ToList();

            // TODO continue implementation
            return new DeliveryPlan[0];
        }

        private IEnumerable<Availability> GetAvailabilities()
        {
            return context.WarehouseOperations
                .Where(x => x.Distributor == null)
                .GroupBy(x => x.Product.Id)
                .Select(x =>
                        new Availability
                        {
                            ProductId = x.Key,
                            Quantity = x.Sum(z => z.Type == WarehouseOperationType.Produced
                                                      ? z.Quantity
                                                      : -z.Quantity)
                        });
        }

        private IEnumerable<Need> GetNeeds()
        {
            var today = Clock.Now.Date;
            var start = today.Subtract(TimeSpan.FromDays(PERIOD));

            return from item in context.WarehouseOperations
                       .Where(x => start <= x.Timestamp && x.Timestamp <= today)
                       .GroupBy(x => x.Distributor.Id)
                       .Select(x =>
                               new
                               {
                                   DistributorId = x.Key,
                                   Products = x.GroupBy(z => z.Product.Id)
                                   .Select(z =>
                                           new
                                           {
                                               ProductId = z.Key,
                                               Rate = z.Sum(c => c.Type == WarehouseOperationType.Sold
                                                                     ? c.Quantity
                                                                     : 0)/PERIOD,
                                               Stock = z.Sum(c => c.Type == WarehouseOperationType.Delivered
                                                                      ? c.Quantity
                                                                      : -c.Quantity)
                                           })
                               })
                   from product in item.Products
                   select new Need
                          {
                              DistributorId = item.DistributorId,
                              ProductId = product.ProductId,
                              Quantity = product.Rate*PERIOD - product.Stock
                          };
        }
    }
}