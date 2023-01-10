using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JewelryShop.Models
{
    public class Categorie
    {
        public int ID { get; set; }
        [Display(Name = "Categorie")]
        public string CategorieNume { get; set; }
        public ICollection<Bijuterie>? Bijuterii { get; set; }
    }
}

