using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using JewelryShop.Data;
using JewelryShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JewelryShop.Pages.Colectii
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
        public Colectie Colectie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Colectie == null)
            {
                return NotFound();
            }

            var colectie =  await _context.Colectie.FirstOrDefaultAsync(m => m.ID == id);
            if (colectie == null)
            {
                return NotFound();
            }
            Colectie = colectie;
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

            _context.Attach(Colectie).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ColectieExists(Colectie.ID))
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

        private bool ColectieExists(int id)
        {
          return _context.Colectie.Any(e => e.ID == id);
        }
    }
}
