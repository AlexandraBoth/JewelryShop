using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using JewelryShop.Data;
using JewelryShop.Models;
using Microsoft.AspNetCore.Authorization;
using System.Data;

namespace JewelryShop.Pages.Colectii
{
    [Authorize(Roles = "Admin")]
    public class CreateModel : PageModel
    {
        private readonly JewelryShop.Data.JewelryShopContext _context;

        public CreateModel(JewelryShop.Data.JewelryShopContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Colectie Colectie { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Colectie.Add(Colectie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
