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
    public class DetailsModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public DetailsModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

      public Vanzare Vanzare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }

            var vanzare = await _context.Vanzari.FirstOrDefaultAsync(m => m.ID == id);
            if (vanzare == null)
            {
                return NotFound();
            }
            else 
            {
                Vanzare = vanzare;
            }
            return Page();
        }
    }
}
