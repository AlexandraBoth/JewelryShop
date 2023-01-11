using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JewelryShop.Pages.Bijuterii
{
    [Authorize(Roles = "Admin")]
    public class DeleteModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public DeleteModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Bijuterie Bijuterie { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bijuterie == null)
            {
                return NotFound();
            }

            var bijuterie = await _context.Bijuterie.Include(b => b.Categorie).Include(b => b.Brand).Include(b => b.Colectie).FirstOrDefaultAsync(m => m.ID == id);

            if (bijuterie == null)
            {
                return NotFound();
            }
            else 
            {
                Bijuterie = bijuterie;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Bijuterie == null)
            {
                return NotFound();
            }
            var bijuterie = await _context.Bijuterie.FindAsync(id);

            if (bijuterie != null)
            {
                Bijuterie = bijuterie;
                _context.Bijuterie.Remove(Bijuterie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
