using Microsoft.AspNetCore.Mvc.RazorPages;

namespace With.ASP.NET.RazorPages.Pages.Examples.LazyLoadingWithSkeleton;

public class ResultModel : PageModel
{
    public async Task OnGet() => await Task.Delay(3000);
}