﻿using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Stores all information about product movements.
    /// </summary>
    public class WarehouseOperation : Identifiable
    {
        /// <summary>
        /// Distributor (if null, then company itself).
        /// </summary>
        public Distributor Distributor { get; set; }

        /// <summary>
        /// Product.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity of product.
        /// </summary>
        public double Quantity { get; set; }

        /// <summary>
        /// Operation type.
        /// </summary>
        public WarehouseOperationType Type { get; set; }

        /// <summary>
        /// Defines whether company itself is mentioned in this operation.
        /// </summary>
        public bool IsCompany { get { return Distributor == null; } }
    }
}