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
using System.IO;
using Microsoft.AspNetCore.Http;

namespace DenchikDance.PagesTournaments
{
    public class EditModel : PageModel
    {
        private readonly DenchikDance.Data.SiteContext _context;

        public EditModel(DenchikDance.Data.SiteContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tournament Tournament { get; set; }
        public IFormFile FormFile { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Tournament = await _context.Tournaments.FirstOrDefaultAsync(m => m.ID == id);

            if (Tournament == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, please enable the specific properties you want to bind to, for
        // more details see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            
            _context.Attach(Tournament).State = EntityState.Modified;

            if (FormFile != null)
                using (var memoryStream = new MemoryStream())
                {
                    await FormFile.CopyToAsync(memoryStream);
                    Tournament.Image = memoryStream.ToArray();
                }
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TournamentExists(Tournament.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool TournamentExists(int id)
        {
            return _context.Tournaments.Any(e => e.ID == id);
        }
    }
}
