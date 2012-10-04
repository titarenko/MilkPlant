using DevExpress.Xpo;

namespace MilkPlant.XpoBackend.Models.Base
{
    public class Named : Identifiable
    {
        [Persistent]
        public string Name { get; set; }
    }
}