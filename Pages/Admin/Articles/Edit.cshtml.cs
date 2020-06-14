using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DenchikDance.Data;
using DenchikDance.Models;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace DenchikDance.Pages_Articles
{
    public class EditModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public EditModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Article Article { get; set; }
        public IFormFile FormFile { get; set; }
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Article = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.User).FirstOrDefaultAsync(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "Title");
           ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "Login");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Attach(Article).State = EntityState.Modified;

            if (FormFile != null)
                using (var memoryStream = new MemoryStream())
                {
                    await FormFile.CopyToAsync(memoryStream);
                    Article.Image = memoryStream.ToArray();
                }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticleExists(Article.ID))
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

        private bool ArticleExists(int id)
        {
            return _context.Articles.Any(e => e.ID == id);
        }
    }
}
