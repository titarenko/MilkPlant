using System;
using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.Interfaces.Models
{
    public class SoldItem : Identifiable
    {
        public Product Product { get; set; }

        public Distributor Distributor { get; set; }

        public DateTime Date { get; set; }

        public decimal Quantity { get; set; }
    }
}