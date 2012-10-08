namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Item of waybill.
    /// </summary>
    public class WaybillItem
    {
        /// <summary>
        /// Product to deliver.
        /// </summary>
        public Product Product { get; set; }

        /// <summary>
        /// Quantity of product to deliver.
        /// </summary>
        public double Quantity { get; set; }
    }
}