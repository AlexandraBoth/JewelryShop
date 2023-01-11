using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JewelryShop.Models
{
    public class Brand
    {
        public int ID { get; set; }
        [Display(Name = "Brand")]
        public string Type { get; set; }
        public string Gen { get; set; }
        public ICollection<Bijuterie>? Bijuterii { get; set; }
    }
}
