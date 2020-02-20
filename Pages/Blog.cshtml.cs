using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DenchikDance.Models;
using Microsoft.EntityFrameworkCore;

namespace DenchikDance.Pages
{
    public class BlogModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public BlogModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }


        public new IList<Post> Post { get;set; }


        public async Task OnGetAsync()
        {
            Post = await _context.Posts.ToListAsync();

        }

        public async Task OnPostAsync()
        {

        }

    }
}
