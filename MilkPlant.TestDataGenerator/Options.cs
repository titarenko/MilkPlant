using System.ComponentModel;

namespace MilkPlant.TestDataGenerator
{
    public class Options
    {
        [Description("Defines how many random objects will be created.")]
        public int Count { get; set; }
    }
}