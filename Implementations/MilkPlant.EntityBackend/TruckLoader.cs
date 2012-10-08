using System.Collections.Generic;
using System.Linq;
using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class TruckLoader
    {
        private readonly IList<Waybill> issued = new List<Waybill>();
        private readonly IDictionary<int, Waybill> current = new Dictionary<int, Waybill>();
        private readonly WaybillPool pool;

        public TruckLoader(WaybillPool pool)
        {
            this.pool = pool;
        }

        public void Load(Distributor distributor, Product product, double quantity)
        {
            var waybill = current.ContainsKey(distributor.Id)
                              ? current[distributor.Id]
                              : pool.GetBlank(distributor);

            quantity = waybill.AddProduct(product, quantity);

            while (quantity > 0)
            {
                issued.Add(waybill);
                
                waybill = pool.GetBlank(distributor);
                current[distributor.Id] = waybill;

                quantity = waybill.AddProduct(product, quantity);
            }
        }

        public IEnumerable<Waybill> GetDeliveryPlan()
        {
            return issued.Concat(current.Values);
        }
    }
}