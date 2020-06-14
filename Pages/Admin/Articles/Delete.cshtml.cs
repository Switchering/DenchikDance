using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using DenchikDance.Data;
using DenchikDance.Models;

namespace DenchikDance.Pages_Articles
{
    public class DeleteModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public DeleteModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }
        public string ErrorMesage { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.User).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ErrorMesage = "Delete failed. Try again";
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var article = await _context.Articles.FindAsync(id);

            if (Article == null)
            {
                return NotFound();
            }

            try
            {
                _context.Articles.Remove(article);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
            catch (DbUpdateException)
            {
                return RedirectToAction("./Delete", new {id, saveChangesError = true});
            }
            
        }
    }
}
