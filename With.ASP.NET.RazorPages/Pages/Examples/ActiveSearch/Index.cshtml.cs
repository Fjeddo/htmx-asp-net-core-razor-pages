using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.ActiveSearch.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.ActiveSearch;

public class IndexModel : PageModel
{
    public async Task<IActionResult> OnPost(string rawSearchString)
    {
        await Task.Delay(1000);

        var searchString = Request.Form["search"].ToString().ToLower();

        var result = Db.Contacts.Where(x =>
            x.FirstName.ToLower().Contains(searchString) ||
            x.LastName.ToLower().Contains(searchString) ||
            x.Email.ToLower().Contains(searchString));

        return Partial("Contacts", result.ToArray());
    }
}