using CDIM3312FinalProject.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;


namespace CDIM3312FinalProject.Pages

{
    public class IndexModel : PageModel
    {
        private readonly CDIM3312FinalProject.Models.AppDbContext _context;

        public IndexModel(CDIM3312FinalProject.Models.AppDbContext context)
        {
            _context = context;
        }

        
        public IList<Product> Product { get;set; } = default!;

        [BindProperty(SupportsGet = true)]

        public int PageNum {get; set;} = 1;
        public int PageSize {get; set;} = 10;
        public int TotalPages {get; set;}


        public async Task OnGetAsync()
        {
            TotalPages = (int)Math.Ceiling(_context.Products.Count() / (double)PageSize);    
            

            Product = await _context.Products.Include(r => r.Reviews!)
                .Skip((PageNum-1)*PageSize).Take(PageSize).ToListAsync();
        }
    }
}