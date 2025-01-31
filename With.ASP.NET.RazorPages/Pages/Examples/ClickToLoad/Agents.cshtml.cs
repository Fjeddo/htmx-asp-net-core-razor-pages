using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using With.ASP.NET.RazorPages.Pages.Examples.ClickToLoad.Data;

namespace With.ASP.NET.RazorPages.Pages.Examples.ClickToLoad;

public class AgentsModel : PageModel
{
    public Agent[] InitialAgents { get; private set; } = [];

    public IActionResult OnGet(int currentPage)
    {
        if (currentPage == 0)
        {
            InitialAgents = Agent.GetAgents(currentPage);
            return Page();
        }

        return Partial("_PagedAgents", (Agents: Agent.GetAgents(currentPage), Page: currentPage));
    }
}