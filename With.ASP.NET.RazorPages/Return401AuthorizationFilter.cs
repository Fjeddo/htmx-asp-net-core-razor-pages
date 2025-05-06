using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace With.ASP.NET.RazorPages;

public class Return401AuthorizationFilter(IAuthorizationService authorizationService) : IAsyncAuthorizationFilter
{
    public async Task OnAuthorizationAsync(AuthorizationFilterContext context)
    {
        var result = await authorizationService.AuthorizeAsync(context.HttpContext.User, null, "Return401");

        if (!result.Succeeded)
        {
            context.Result = new UnauthorizedObjectResult("You are not logged in!");
        }
    }
}