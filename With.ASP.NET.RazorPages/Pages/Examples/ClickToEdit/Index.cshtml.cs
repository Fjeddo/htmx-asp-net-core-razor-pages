using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.ClickToEdit.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.ClickToEdit;

public class IndexModel : PageModel
{
    public ContactInfo? ContactInfo { get; private set; }

    public void OnGet(int id) => ContactInfo = Db.Contacts.FirstOrDefault(x => x.ID == id)!;

    public IActionResult OnGetView(int id) => Partial("_View", Db.Contacts.FirstOrDefault(x => x.ID == id));

    public IActionResult OnGetEdit(int id) => Partial("_Edit", Db.Contacts.FirstOrDefault(x => x.ID == id));

    public IActionResult OnPut([FromForm] ContactInfo contactInfo)
    {
        Db.Upsert(contactInfo);
        return Partial("_View", contactInfo);
    }
}