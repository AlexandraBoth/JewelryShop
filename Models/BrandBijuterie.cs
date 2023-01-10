namespace JewelryShop.Models
{
    public class BrandBijuterie
    {
        public int ID { get; set; }
        public int BijuterieID { get; set; }
        public Bijuterie Bijuterie { get; set; }
        public int BrandID { get; set; }
        public Brand Brand { get; set; }
    }
}
