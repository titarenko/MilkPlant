using System;
using System.Collections.Generic;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class DeliveryManager : IDeliveryManager
    {
        private readonly SalesAnalytics analytics;
        private readonly CompanyWarehouse warehouse;
        private readonly TruckLoader loader;

        public DeliveryManager(SalesAnalytics analytics, CompanyWarehouse warehouse, TruckLoader loader)
        {
            this.analytics = analytics;
            this.warehouse = warehouse;
            this.loader = loader;
        }

        public IEnumerable<Waybill> GetDeliveryPlan(DateTime date)
        {
            try
            {
                foreach (var need in analytics.GetCurrentNeeds())
                {
                    var available = warehouse.GetAvailableItemsCount(need.Product);
                    if (available > 0)
                    {
                        var quantity = Math.Min(need.Quantity, available);
                        loader.Load(need.Distributor, need.Product, quantity);
                        warehouse.Consume(need.Product, quantity);
                    }
                }
            }
            catch (OutOfWaybillsException)
            {
            }

            return loader.GetDeliveryPlan();
        }
    }
}