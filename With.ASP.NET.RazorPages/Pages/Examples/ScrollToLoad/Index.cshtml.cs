using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.ScrollToLoad.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.ScrollToLoad;

public class IndexModel : PageModel
{
    public Agent[] InitialAgents { get; private set; } = [];

    public async Task<IActionResult> OnGet(int currentPage)
    {
        if (currentPage == 0)
        {
            InitialAgents = Agent.GetAgents(currentPage);
            return Page();
        }

        await Task.Delay(1500);
        return Partial("_PagedAgents", (Agents: Agent.GetAgents(currentPage), Page: currentPage));
    }
}