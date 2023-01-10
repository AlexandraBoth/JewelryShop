using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;

namespace JewelryShop.Pages.Vanzari
{
    public class IndexModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public IndexModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        public IList<Vanzare> Vanzare { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Vanzari != null)
            {
                Vanzare = await _context.Vanzari
                .Include(v => v.Bijuterie)
                .Include(v => v.Membru).ToListAsync();
            }
        }
    }
}
