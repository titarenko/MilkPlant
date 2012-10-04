using MilkPlant.Interfaces.Models.Base;

namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Vehicle owned by company and used for product delivery for distributors.
    /// </summary>
    public class Truck : Identifiable
    {
        /// <summary>
        /// Registration number (license plate text).
        /// </summary>
        public string LicensePlate { get; set; }

        /// <summary>
        /// Total quantity of products items that can be delivered by this truck at one time.
        /// </summary>
        public double Capacity { get; set; }

        /// <summary>
        /// Average speed in km/h.
        /// </summary>
        public double Speed { get; set; }
    }
}