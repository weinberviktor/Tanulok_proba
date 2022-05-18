using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Tanulok_proba.Data;
using Tanulok_proba.Model;

namespace Tanulok_proba.Pages
{
    public class CreateModel : PageModel
    {
        private readonly Tanulok_proba.Data.ApplicationDbContext _context;

        public CreateModel(Tanulok_proba.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Tanar Tanar { get; set; } = default!;
        
        public async Task<IActionResult> OnPostAsync()
        {
            Tanar.TanarDiak = new List<TanarDiak>();
            if (!ModelState.IsValid || _context.Tanarok == null || Tanar == null) //? :(
            {
                return Page();
            }
            
            _context.Tanarok.Add(Tanar);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
