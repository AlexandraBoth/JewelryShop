using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;

namespace JewelryShop.Pages.Bijuterii
{
    [Authorize(Roles = "Admin")]
    public class EditModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public EditModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Bijuterie Bijuterie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Bijuterie == null)
            {
                return NotFound();
            }

            var bijuterie =  await _context.Bijuterie.FirstOrDefaultAsync(m => m.ID == id);
            if (bijuterie == null)
            {
                return NotFound();
            }
            Bijuterie = bijuterie;
            ViewData["CategorieID"] = new SelectList(_context.Set<Categorie>(), "ID", "CategorieNume");
            ViewData["BrandID"] = new SelectList(_context.Set<Brand>(), "ID", "Brand");
            ViewData["ColectieID"] = new SelectList(_context.Set<Colectie>(), "ID", "Colect");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Bijuterie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BijuterieExists(Bijuterie.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool BijuterieExists(int id)
        {
          return _context.Bijuterie.Any(e => e.ID == id);
        }
    }
}
