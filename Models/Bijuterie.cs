using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace JewelryShop.Models
{
    public class Bijuterie
    {
        public int ID { get; set; }
        [Display(Name = "Nume bijuterie")]
        public string Nume { get; set; }
        
        [Column(TypeName = "decimal(6, 2)")]
        public decimal Pret { get; set; }
        public int? CategorieID { get; set; }
        public Categorie? Categorie { get; set; }
        public int? BrandID { get; set; }
        public Brand? Brand { get; set; }
        public int? ColectieID { get; set; }
        public Colectie? Colectie { get; set; }
     
    }
}
