using System;
using System.Collections.Generic;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.Interfaces
{
    public interface IDeliveryManager
    {
        /// <summary>
        /// Returns delivery plan for given date.
        /// </summary>
        IEnumerable<DeliveryPlan> GetDeliveryPlan(DateTime date);
    }
}