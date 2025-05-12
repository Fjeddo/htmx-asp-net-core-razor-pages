using System.Net;
using Htmx;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Click_Hello_Time.Pages
{
    public class ResponseTargetsModel : PageModel
    {
        public IActionResult OnGet(int status)
        {
            if (Request.IsHtmx())
            {
                return new ObjectResult($"<marquee>{status} - {(status == 418 ? "I'm a teapot" : (HttpStatusCode)status)}</marquee>") { StatusCode = status };
            }

            return Page();
        }
    }
}
