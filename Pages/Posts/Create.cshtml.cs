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
        [BindProperty]
        public BufferedFile FileUpload { get; set; }

        public class BufferedFile
        {
            [Required]
            [Display(Name="File")]
            public IFormFile FormFile { get; set; }
        }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            var emptyPost = new Post(); 
            if (FileUpload.FormFile != null)
            {
                using (var memoryStream = new MemoryStream())
                {
                    await FileUpload.FormFile.CopyToAsync(memoryStream);
                    if(memoryStream.Length<5000000)
                    {
                        Post.Image =memoryStream.ToArray();
                    }
                }
            }
            
            if (await TryUpdateModelAsync<Post>(
            emptyPost,
            "post",
            p => p.Title, p => p.Description, p => p.Text, p => p.CategoryID, p => p.UserID))
            {
                _context.Posts.Add(Post);
                await _context.SaveChangesAsync();
                return RedirectToPage("./Index");
            }
              return RedirectToPage("./Index"); 
        }
    }
}
