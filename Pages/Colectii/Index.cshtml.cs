using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;

namespace JewelryShop.Pages.Colectii
{
    public class IndexModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public IndexModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        public IList<Colectie> Colectie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Colectie != null)
            {
                Colectie = await _context.Colectie.ToListAsync();
            }
        }
    }
}
