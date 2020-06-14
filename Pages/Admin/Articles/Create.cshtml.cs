using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using DenchikDance.Data;
using DenchikDance.Models;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.IO;

namespace DenchikDance.Pages_Articles
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
        public Article Article { get; set; }
        [BindProperty]
        public IFormFile FormFile { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (FormFile.Length > 0)
                using (var memoryStream = new MemoryStream())
                {
                    await FormFile.CopyToAsync(memoryStream);
                    Article.Image = memoryStream.ToArray();
                }
            else
            Article.Image = new byte[0];

            if (!ModelState.IsValid)
                {
                    return Page();
                }

            _context.Articles.Add(Article);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }  
    }
}
