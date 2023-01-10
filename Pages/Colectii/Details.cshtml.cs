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
    public class DetailsModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public DetailsModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

      public Colectie Colectie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colectie == null)
            {
                return NotFound();
            }

            var colectie = await _context.Colectie.FirstOrDefaultAsync(m => m.ID == id);
            if (colectie == null)
            {
                return NotFound();
            }
            else 
            {
                Colectie = colectie;
            }
            return Page();
        }
    }
}
