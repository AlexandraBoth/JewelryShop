using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;

namespace JewelryShop.Pages.Bijuterii
{
    public class IndexModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public IndexModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        public IList<Bijuterie> Bijuterie { get; set; } = default!;

       
        public BijuterieData BijuterieD { get; set; }
        public int BijuterieID { get; set; }
        public int BrandID { get; set; }

        public string NumeSort { get; set; }
      
        public string CurrentFilter { get; set; }
        public async Task OnGetAsync(int? id, int? TipID, string sortOrder, string searchString)
        {
            BijuterieD = new BijuterieData();

            NumeSort = String.IsNullOrEmpty(sortOrder) ? "nume_desc" : "";
            

            CurrentFilter = searchString;

            BijuterieD.Bijuterii = await _context.Bijuterie
                .Include(b => b.Categorie)
                .Include(b => b.Brand)
                .Include(b => b.Colectie)
                .AsNoTracking()
                .OrderBy(b => b.Nume)
                .ToListAsync();
            if (!String.IsNullOrEmpty(searchString))
            {
                BijuterieD.Bijuterii = BijuterieD.Bijuterii.Where(s => s.Brand.Type.Contains(searchString)

                || s.Brand.Type.Contains(searchString)
                || s.Nume.Contains(searchString));
            
            }



            if (id != null)
            {
                BijuterieID = id.Value;
                Bijuterie bijuterie = BijuterieD.Bijuterii
                .Where(i => i.ID == id.Value).Single();

            }
            switch (sortOrder)
            {
                case "nume_desc":
                    BijuterieD.Bijuterii = BijuterieD.Bijuterii.OrderByDescending(s =>
                   s.Nume);
                    break;
                
                    
            }
        }

    }
    
}

