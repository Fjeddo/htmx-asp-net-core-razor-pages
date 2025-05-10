using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Click_Hello_Time.Pages.jQuery
{
    public class IndexModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnGetOrebro()
        {
            var dateTimeHere = DateTimeOffset.Now;

            return Partial(
                "_Time",
                TimeZoneInfo.ConvertTime(dateTimeHere, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"))
            );
        }
    }
}
