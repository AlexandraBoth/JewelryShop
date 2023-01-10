namespace JewelryShop.Models
{
    public class BijuterieData
    {
        public IEnumerable<Bijuterie> Bijuterii { get; set; }
        public IEnumerable<Brand> Branduri { get; set; }
        public IEnumerable<BrandBijuterie> BranduriBijuterie { get; set; }
    }
}
