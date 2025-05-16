using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CDIM3312FinalProject.Models;

namespace CDIM3312FinalProject.Pages_Products
{
    public class IndexModel : PageModel
    {
        private readonly CDIM3312FinalProject.Models.AppDbContext _context;

        public IndexModel(CDIM3312FinalProject.Models.AppDbContext context)
        {
            _context = context;
        }

        public IList<Product> Product { get;set; } = default!;

        public async Task OnGetAsync()
        {
            Product = await _context.Products.Include(p => p.Reviews).ToListAsync();
        }
    }
}
