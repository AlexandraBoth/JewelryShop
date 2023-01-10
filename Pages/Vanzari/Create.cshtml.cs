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
    public class CreateModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public CreateModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            var bijuterieList = _context.Bijuterie
                  .Include(b => b.Brand)
                  .Select(x => new { x.ID, Nume = x.Nume + " - " + x.Brand.Type + " " + x.Colectie.Colect });
            ViewData["BijuterieID"] = new SelectList(bijuterieList, "ID", "Nume");
        ViewData["MembruID"] = new SelectList(_context.Membru, "ID", "NumeComplet");
            return Page();
        }

        [BindProperty]
        public Vanzare Vanzare { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Vanzari.Add(Vanzare);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
