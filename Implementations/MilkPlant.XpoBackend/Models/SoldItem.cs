using System;
using DevExpress.Xpo;
using MilkPlant.XpoBackend.Models.Base;

namespace MilkPlant.XpoBackend.Models
{
    [Persistent]
    public class SoldItem : Identifiable
    {
        [Persistent]
        public int ProductId { get; set; }

        [Association]
        public Product Product { get; set; }

        [Persistent]
        public int DistributorId { get; set; }

        [Association]
        public Distributor Distributor { get; set; }

        [Persistent]
        public DateTime Date { get; set; }

        [Persistent]
        public decimal Quantity { get; set; }
    }
}