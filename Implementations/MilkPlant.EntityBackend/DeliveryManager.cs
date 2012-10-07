using System;
using System.Collections.Generic;
using MilkPlant.Interfaces;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class DeliveryManager : IDeliveryManager
    {
        public IEnumerable<DeliveryPlan> GetDeliveryPlan(DateTime date)
        {
            return new List<DeliveryPlan>(); // TODO actual implementation
        }
    }
}