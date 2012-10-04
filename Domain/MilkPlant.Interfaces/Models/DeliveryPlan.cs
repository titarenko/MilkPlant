using System;

namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Delivery plan item.
    /// </summary>
    public class DeliveryPlan
    {
        /// <summary>
        /// Truck which will carry product items.
        /// </summary>
        public Truck Truck { get; set; }

        /// <summary>
        /// Target distributor.
        /// </summary>
        public Distributor Distributor { get; set; }

        /// <summary>
        /// Product to deliver.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity of product to deliver.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Delivery start date (date and time when truck should leave company warehouse 
        /// and start moving to distributor warehouse).
        /// </summary>
        public DateTime Date { get; set; }
    }
 }