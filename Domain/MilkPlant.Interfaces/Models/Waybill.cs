using System;
using System.Collections.Generic;
using System.Linq;

namespace MilkPlant.Interfaces.Models
{
    public class Waybill
    {
        /// <summary>
        /// Truck.
        /// </summary>
        public Truck Truck { get; set; }

        /// <summary>
        /// Date and time when truck will leave company warehouse.
        /// </summary>
        public DateTime Departure { get; set; }

        /// <summary>
        /// Destination.
        /// </summary>
        public Distributor Distributor { get; set; }

        /// <summary>
        /// Items.
        /// </summary>
        public IList<WaybillItem> WaybillItems { get; set; }

        /// <summary>
        /// Tries to add as much as possible of product items to waybill and returns excess.
        /// </summary>
        /// <param name="product">Product to add.</param>
        /// <param name="quantity">Quantity of product items to add.</param>
        /// <returns>Excess (quantity of product items which will not be added to current waybill).</returns>
        public double AddProduct(Product product, double quantity)
        {
            var load = WaybillItems.Sum(x => x.Quantity);
            var free = Truck.Capacity - load;
            if (free > 0)
            {
                var acceptedQuantity = Math.Min(free, quantity);
                WaybillItems.Add(
                    new WaybillItem
                    {
                        Product = product,
                        Quantity = acceptedQuantity
                    });
                return quantity - acceptedQuantity;
            }
            return quantity;
        }
    }
}