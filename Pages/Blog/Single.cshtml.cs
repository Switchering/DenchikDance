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
    public class SingleModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public SingleModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        public IList<Article> Articles { get;set; }
        public Article Article { get; set; }


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Articles = await _context.Articles
                .Include(a => a.Category)
                .Include(a => a.User).OrderByDescending(a => a).ToListAsync();

            Article = Articles.FirstOrDefault(m => m.ID == id);

            if (Article == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IList<Article> GetLatest()
        {
            List<Article> latest = new List<Article>();
            latest = Articles.SkipLast(Articles.Count - 3).ToList();
            return latest;
        }

        public IActionResult OnGetPartial() =>
            Partial("_BlogPartial");
    }
}