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
            Article = await _context.Articles
                .Include(p => p.Category)
                .Include(p => p.User).ToListAsync();
        }
    }
}
