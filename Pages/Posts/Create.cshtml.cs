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
        public IFormFile FormFile { get; set; }
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (FormFile.Length > 0)
                using (var memoryStream = new MemoryStream())
                {
                    await FormFile.CopyToAsync(memoryStream);
                    Post.Image = memoryStream.ToArray();
                }
            else
            Post.Image = new byte[0];

            if (!ModelState.IsValid)
                {
                    return Page();
                }

                _context.Posts.Add(Post);
                await _context.SaveChangesAsync();

                return RedirectToPage("./Index");
        }

        public async Task<IActionResult> OnPostUploadAsync(List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);

            foreach (var formFile in files)
            {
                if (formFile.Length > 0)
                {
                    var filePath = Path.GetTempFileName();
                    using ( var stream = System.IO.File.Create(filePath))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }
            return Page();
        }        

        // public async Task<IActionResult> OnPostUploadAsync()
        // {
        //     MemoryStream mem = new MemoryStream();

        //         using (var memoryStream = new MemoryStream())
        //         {
        //             await FormFile.CopyToAsync(memoryStream);
        //             if (memoryStream.Length < 2000000)
        //             System.Diagnostics.Debug.WriteLine(memoryStream.Length.ToString());
        //             Post.Image = memoryStream.ToArray();
        //         }
        //     var emptyPost = new Post(); 
        //     if (await TryUpdateModelAsync<Post>(
        //     emptyPost,
        //     "post",
        //     p => p.Title, p => p.Description, p => p.Text, p => p.CategoryID, p => p.UserID))
        //     {
        //         _context.Posts.Add(Post);
        //         await _context.SaveChangesAsync();
        //         return RedirectToPage("./Index");
        //     }
        //     return RedirectToPage("./Index"); 
        // }
    }
}
