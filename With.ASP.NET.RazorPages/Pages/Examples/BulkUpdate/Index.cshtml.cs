using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.BulkUpdate.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.BulkUpdate;

public class IndexModel : PageModel
{
    public List<Contact> Contacts { get; set; } = Db.Contacts;

    public IActionResult OnPost()
    {
        if (Request.IsHtmx())
        {
            var activated = 0;
            var deactivated = 0;
            var activeInForm = Request.Form.Keys.Where(x => x.StartsWith("active:")).ToArray();

            foreach (var contact in Contacts)
            {
                var endsWith = $":{contact.Email}";
                var isDeactivated = contact.Active && !activeInForm.Any(x => x.EndsWith(endsWith));
                if (!isDeactivated)
                {
                    var isActivated = !contact.Active && activeInForm.Any(x => x.EndsWith(endsWith));
                    if (isActivated)
                    {
                        contact.Active = true;
                        activated++;
                    }
                }
                else
                {
                    contact.Active = false;
                    deactivated++;
                }
            }

            return Partial("_Toast", (activated, deactivated));
        }

        return Page();
    }

}