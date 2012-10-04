using DevExpress.Xpo;

namespace MilkPlant.XpoBackend.Models.Base
{
    public class Identifiable
    {
        [Key(AutoGenerate = true)]
        public int Id { get; set; }
    }
}