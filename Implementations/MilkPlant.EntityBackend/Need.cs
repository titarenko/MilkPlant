using MilkPlant.Interfaces.Models;

namespace MilkPlant.EntityBackend
{
    public class Need
    {
        public Distributor Distributor { get; set; }

        public Product Product { get; set; }

        public double Quantity { get; set; }
    }
}