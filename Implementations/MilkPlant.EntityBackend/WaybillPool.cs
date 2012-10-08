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
        private const int BEGIN_OF_DAY = 8;
        private const int END_OF_DAY = 20;

        public WaybillPool(IEnumerable<Truck> trucks)
        {
            waybills = trucks
                .Select(truck =>
                        new Waybill
                        {
                            DepartureTime = Clock.Now.Date + TimeSpan.FromHours(BEGIN_OF_DAY),
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
            var departure = waybill.DepartureTime + GetRouteLength(waybill);
            if (departure.Date < Clock.Now.Date.AddHours(END_OF_DAY))
            {
                waybills.Add(
                    new Waybill
                    {
                        DepartureTime = departure,
                        Truck = waybill.Truck
                    });
            }
        }

        private static TimeSpan GetRouteLength(Waybill waybill)
        {
            return TimeSpan.FromHours(2*waybill.Distributor.Distance/waybill.Truck.AverageSpeed);
        }
    }
}