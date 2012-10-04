namespace MilkPlant.Interfaces.Models.Base
{
    /// <summary>
    /// Defines properties of named entity.
    /// </summary>
    public abstract class Named : Identifiable
    {
        /// <summary>
        /// Common designation.
        /// </summary>
        public string Name { get; set; }
    }
}