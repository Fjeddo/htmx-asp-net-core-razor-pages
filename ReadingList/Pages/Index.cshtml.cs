using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReadingList.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGet(string id)
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return Page();
            }

            return Partial("_List", Db.Books.ToArray());
        }

        public IActionResult OnPostSearch()
        {
            var search = Request.Form["search"];

            return Partial("_List", Db.Books.Where(x => 
                x.title.Contains(search, StringComparison.InvariantCultureIgnoreCase) ||
                x.author.Contains(search, StringComparison.InvariantCultureIgnoreCase)).ToArray());
        }
        
        public IActionResult OnPost()
        {
            throw new NotImplementedException();
        }

        public IActionResult OnDelete(string id)
        {
            throw new NotImplementedException();
        }

        public IActionResult OnPut(string id)
        {
            throw new NotImplementedException();
        }

        public IActionResult OnGetEdit(string id)
        {
            throw new NotImplementedException();
        }
    }
}
