using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Tanulok_proba.Data;
using Tanulok_proba.Model;

namespace Tanulok_proba.Pages
{
    public class DeleteModel : PageModel
    {
        private readonly Tanulok_proba.Data.ApplicationDbContext _context;

        public DeleteModel(Tanulok_proba.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Tanar Tanar { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Tanarok == null)
            {
                return NotFound();
            }

            var tanar = await _context.Tanarok.FirstOrDefaultAsync(m => m.Id == id);

            if (tanar == null)
            {
                return NotFound();
            }
            else 
            {
                Tanar = tanar;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Tanarok == null)
            {
                return NotFound();
            }
            var tanar = await _context.Tanarok.FindAsync(id);

            if (tanar != null)
            {
                Tanar = tanar;
                _context.Tanarok.Remove(Tanar);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
