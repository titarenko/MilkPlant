using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Contractor who sells products produced by company.
    /// </summary>
    public class Distributor : Named
    {
        /// <summary>
        /// Distance in km between company and distributor warehouses.
        /// </summary>
        public double Distance { get; set; }
    }
}