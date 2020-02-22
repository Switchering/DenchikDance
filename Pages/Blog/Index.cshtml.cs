using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using DenchikDance.Models;
using Microsoft.EntityFrameworkCore;

namespace Pages_Blog
{
    public class IndexModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public IndexModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }
        public IList<Article> Article { get;set; }


        public async Task OnGetAsync()
        {
            Article = await _context.Articles.OrderByDescending(a => a).ToListAsync();
        }
    }
}