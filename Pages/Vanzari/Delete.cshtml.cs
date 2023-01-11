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
    public class DeleteModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public DeleteModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Vanzare Vanzare { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }

            var vanzare = await _context.Vanzari.Include(b => b.Membru).Include(b => b.Bijuterie).FirstOrDefaultAsync(m => m.ID == id);

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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }
            var vanzare = await _context.Vanzari.FindAsync(id);

            if (vanzare != null)
            {
                Vanzare = vanzare;
                _context.Vanzari.Remove(Vanzare);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
