namespace MilkPlant.Interfaces.Models
{
    /// <summary>
    /// Defines set of warehouse operation types.
    /// </summary>
    public enum WarehouseOperationType
    {
        /// <summary>
        /// Product was produced by company.
        /// </summary>
        Produced,

        /// <summary>
        /// Product was sent to distributor warehouse from company warehouse.
        /// </summary>
        Sent,

        /// <summary>
        /// Product was delivered to distributor warehouse from company warehouse.
        /// </summary>
        Delivered,

        /// <summary>
        /// Product was sold by distributor.
        /// </summary>
        Sold
    }
}