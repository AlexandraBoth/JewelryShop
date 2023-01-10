using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;

namespace JewelryShop.Models
{
    public class Vanzare
    {
        public int ID { get; set; }
        public int? MembruID { get; set; }
        public Membru? Membru { get; set; }
        public int? BijuterieID { get; set; }
        public Bijuterie? Bijuterie { get; set; }
        [DataType(DataType.Date)] public DateTime DataCumparare { get; set; }
    }
}
