using Microsoft.AspNetCore.Mvc.RazorPages;

namespace With.ASP.NET.RazorPages.Pages.Examples.LazyLoading;

public class GraphModel : PageModel
{
    public async Task OnGet() => await Task.Delay(3000);
}