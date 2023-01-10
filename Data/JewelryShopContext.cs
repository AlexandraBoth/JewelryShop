using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Models;

namespace JewelryShop.Data
{
    public class JewelryShopContext : DbContext
    {
        public JewelryShopContext (DbContextOptions<JewelryShopContext> options)
            : base(options)
        {
        }

        public DbSet<JewelryShop.Models.Bijuterie> Bijuterie { get; set; } = default!;

        public DbSet<JewelryShop.Models.Categorie> Categorie { get; set; }

        public DbSet<JewelryShop.Models.Brand> Brand { get; set; }

        public DbSet<JewelryShop.Models.Colectie> Colectie { get; set; }

        public DbSet<JewelryShop.Models.Vanzare> Vanzari { get; set; }

        public DbSet<JewelryShop.Models.Membru> Membru { get; set; }
    }
}
