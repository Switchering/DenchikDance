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

namespace DenchikDance.Pages_Posts
{
    public class EditModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public EditModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Post Post { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Post = await _context.Posts
                .Include(p => p.Category)
                .Include(p => p.User).FirstOrDefaultAsync(m => m.ID == id);

            if (Post == null)
            {
                return NotFound();
            }
           ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "ID");
           ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "ID");
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var postToUpdate = await _context.Posts.Include(p => p.Category)
                .Include(p => p.User).FirstOrDefaultAsync(m => m.ID == id);
            
            if (postToUpdate == null)
            {
                return NotFound();
            }

            if (await TryUpdateModelAsync<Post>(
                postToUpdate,
                "post",
                p => p.Title, p => p.Description, p => p.Text, p => p.CategoryID, p => p.UserID))
            {
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }

        private bool PostExists(int id)
        {
            return _context.Posts.Any(e => e.ID == id);
        }
    }
}
