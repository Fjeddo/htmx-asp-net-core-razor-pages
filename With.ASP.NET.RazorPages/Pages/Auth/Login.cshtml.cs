using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace With.ASP.NET.RazorPages.Pages.Auth;

[Authorize]
public class LoginModel : PageModel
{
    public IActionResult OnGet()
    {
        return RedirectToPage("/Auth/Index");
    }
}