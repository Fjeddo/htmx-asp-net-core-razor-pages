using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.DeleteRow.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.DeleteRow;

public class IndexModel : PageModel
{
    public List<Person> People { get; set; } = Db.People;

    public IActionResult OnDelete(int id)
    {
        Db.People.RemoveAll(x => x.Id == id);
        //return Partial("_Empty"); // Used with hx-swap=outerHTML
        return new OkResult(); // Used with hx-swap=delete
    }
}