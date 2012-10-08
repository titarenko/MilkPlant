using System;
using System.Collections.Generic;
using System.Linq;
using MilkPlant.Interfaces.Models;
using MilkPlant.Shared;

namespace MilkPlant.EntityBackend
{
    public class WaybillPool
    {
        private readonly IList<Waybill> waybills;

        public WaybillPool(IEnumerable<Truck> trucks)
        {
            waybills = trucks
                .Select(truck =>
                        new Waybill
                        {
                            Departure = Clock.Now.Date + TimeSpan.FromHours(8),
                            Truck = truck
                        })
                .ToList();
        }

        public Waybill GetBlank(Distributor distributor)
        {
            var waybill = waybills.FirstOrDefault();
            if (waybill == null)
            {
                throw new OutOfWaybillsException();
            }

            waybill.Distributor = distributor;
            RecycleTruck(waybill);

            return waybill;
        }

        private void RecycleTruck(Waybill waybill)
        {
            var departure = waybill.Departure + GetRouteLength(waybill);
            if (departure.Date < Clock.Now.Date.AddHours(20))
            {
                waybills.Add(
                    new Waybill
                    {
                        Departure = departure,
                        Truck = waybill.Truck
                    });
            }
        }

        private static TimeSpan GetRouteLength(Waybill waybill)
        {
            return TimeSpan.FromHours(2*waybill.Distributor.Distance/waybill.Truck.Speed);
        }
    }
}