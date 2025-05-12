using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Click_Hello_Time.Pages;

public class PreloadModel : PageModel
{
    public IActionResult OnGetOrebro()
    {
        var dateTimeHere = DateTimeOffset.Now;

        return Partial(
            "_Time",
            TimeZoneInfo.ConvertTime(dateTimeHere, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"))
        );
    }

    public IActionResult OnGetStockholm()
    {
        var dateTimeHere = DateTimeOffset.Now;

        return Partial(
            "_Time",
            TimeZoneInfo.ConvertTime(dateTimeHere, TimeZoneInfo.FindSystemTimeZoneById("W. Europe Standard Time"))
        );
    }
}