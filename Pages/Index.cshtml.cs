using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using DenchikDance.Models;
using Microsoft.EntityFrameworkCore;

namespace DenchikDance.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly DenchikDance.Data.SiteContext _context;

        public IndexModel(ILogger<IndexModel> logger, DenchikDance.Data.SiteContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IList<Article> Articles { get; set; }
        public IList<Category> Categories { get; set; }
        public IList<Tournament> Tournaments { get; set; }

        public async Task OnGetAsync()
        {
            Articles = await _context.Articles.ToListAsync();
            Categories = await _context.Categories.ToListAsync();
            Tournaments = await _context.Tournaments.ToListAsync();
        }
        
        public IList<Article> GetLatestArticles(int count)
        {
            List<Article> latest = new List<Article>();
            latest = Articles.SkipLast(Articles.Count - count).ToList();
            return latest;
        }

        public IList<Tournament> GetLatestTournaments(int count)
        {
            List<Tournament> latest = new List<Tournament>();
            latest = Tournaments.SkipLast(Tournaments.Count - count).ToList();
            return latest;
        }
    }
}
