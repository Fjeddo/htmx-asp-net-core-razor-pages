using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;

namespace With.ASP.NET.RazorPages.Pages
{
        public class IndexModel : PageModel
        {
            public IActionResult OnPost()
            {
                Examples.BulkUpdate.Data.Db.Reset();
                Examples.ClickToEdit.Data.Db.Reset();
                Examples.DeleteRow.Data.Db.Reset();
                Examples.EditRow.Data.Db.Reset();

                return Content("All data reset");
            }
        }
}
