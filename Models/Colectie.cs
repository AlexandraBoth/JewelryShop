using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JewelryShop.Models
{
    public class Colectie
    {
        public int ID { get; set; }
        [Display(Name = "Colectie")]
        public string Colect { get; set; }
        public ICollection<Bijuterie>? Bijuterii { get; set; }
    }
}
