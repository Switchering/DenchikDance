using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DenchikDance.Data;
using DenchikDance.Models;

namespace DenchikDance.Pages_Posts
{
    public class CreateModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public CreateModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CategoryID"] = new SelectList(_context.Set<Category>(), "ID", "Title");
        ViewData["UserID"] = new SelectList(_context.Set<User>(), "ID", "Login");
            return Page();
        }

        [BindProperty]
        public Post Post { get; set; }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPost = new Post();

            if (await TryUpdateModelAsync<Post>(
                emptyPost,
                "post",
                p => p.Title, p => p.Description, p => p.Text, p => p.CategoryID, p => p.UserID))
            {
                _context.Posts.Add(Post);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }

            return Page();
        }
    }
}
