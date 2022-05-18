using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Tanulok_proba.Data;
using Tanulok_proba.Model;

namespace Tanulok_proba.Pages
{
    public class EditModel : PageModel
    {
        private readonly Tanulok_proba.Data.ApplicationDbContext _context;

        public EditModel(Tanulok_proba.Data.ApplicationDbContext context)
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

            var tanar =  await _context.Tanarok.FirstOrDefaultAsync(m => m.Id == id);
            if (tanar == null)
            {
                return NotFound();
            }
            Tanar = tanar;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tanar).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TanarExists(Tanar.Id))
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

        private bool TanarExists(int id)
        {
          return (_context.Tanarok?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
