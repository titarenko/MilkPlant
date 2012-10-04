namespace MilkPlant.Interfaces.Models.Base
{
    /// <summary>
    /// Defines properties of identifiable entity.
    /// </summary>
    public abstract class Identifiable
    {
        /// <summary>
        /// Unique identifier.
        /// </summary>
        public int Id { get; set; }
    }
}