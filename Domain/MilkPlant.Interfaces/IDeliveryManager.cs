using System;
using System.Collections.Generic;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.Interfaces
{
    public interface IDeliveryManager
    {
        /// <summary>
        /// Returns current delivery plan.
        /// </summary>
        IEnumerable<Waybill> GetDeliveryPlan(DateTime date);
    }
}