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

namespace JewelryShop.Pages.Vanzari
{
    public class EditModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public EditModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Vanzare Vanzare { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Vanzari == null)
            {
                return NotFound();
            }

            var vanzare =  await _context.Vanzari.FirstOrDefaultAsync(m => m.ID == id);
            if (vanzare == null)
            {
                return NotFound();
            }
            Vanzare = vanzare;
           ViewData["BijuterieID"] = new SelectList(_context.Bijuterie, "ID", "ID");
           ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "ID");
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

            _context.Attach(Vanzare).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VanzareExists(Vanzare.ID))
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

        private bool VanzareExists(int id)
        {
          return _context.Vanzari.Any(e => e.ID == id);
        }
    }
}
