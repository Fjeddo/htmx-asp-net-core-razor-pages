using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.DeleteRow.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.DeleteRow;

public class PeopleModel : PageModel
{
    public List<Person> People { get; set; } = Db.People;

    public IActionResult OnDelete(int id)
    {
        Db.People.RemoveAll(x => x.Id == id);
        return Partial("_Empty");
    }
}