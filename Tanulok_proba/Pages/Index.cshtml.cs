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
    public class IndexModel : PageModel
    {
        private readonly Tanulok_proba.Data.ApplicationDbContext _context;

        public IndexModel(Tanulok_proba.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tanar> Tanar { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Tanarok != null)
            {
                Tanar = await _context.Tanarok.ToListAsync();
            }
        }
    }
}
