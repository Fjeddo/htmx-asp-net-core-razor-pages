using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.ClickToEdit.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.ClickToEdit;

public class ContactModel : PageModel
{
    public ContactInfo? ContactInfo { get; set; }

    public void OnGet(int id) 
        => ContactInfo ??= Db.Contacts.FirstOrDefault(x => x.ID == id);

    public void OnPut([FromForm] ContactInfo contactInfo)
        => ContactInfo ??= Db.Upsert(contactInfo);
}