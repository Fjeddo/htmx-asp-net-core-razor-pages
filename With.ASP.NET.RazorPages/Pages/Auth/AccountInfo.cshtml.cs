using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace With.ASP.NET.RazorPages.Pages.Auth;

[ServiceFilter(typeof(Return401AuthorizationFilter))]
public class AccountInfoModel : PageModel
{
    public required string[] Claims { get; set; }

    public void OnGet() => Claims = HttpContext.User.Claims.ToList().Select(x => $"{x.Type}: {x.Value}").ToArray();
}