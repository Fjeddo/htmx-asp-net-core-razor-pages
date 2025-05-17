using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.EditRow.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.EditRow;

public class IndexModel : PageModel
{
    public List<Person> People { get; set; } = Db.People;

    public IActionResult OnGetEdit(int id) => Partial("_Edit", Db.People.FirstOrDefault(x => x.Id == id));
    
    public IActionResult OnGetView(int id) => Partial("_View", Db.People.FirstOrDefault(x => x.Id == id));
    
    public IActionResult OnPut(string id, string name, string email)
    {
        var identity = int.Parse(id);
        var person = Db.People.FirstOrDefault(x => x.Id == identity);

        if (person != null)
        {
            person.Name = name;
            person.Email = email;
        }

        return Partial("_View", person);
    }
}