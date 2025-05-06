using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Mvc.Abstractions;

namespace With.ASP.NET.RazorPages.Pages.SignalR;

public class IndexModel : PageModel
{
    private readonly IHubContext<MessageHub> _messageHubContext;
    private readonly IRazorViewEngine _viewEngine;
    private readonly ITempDataProvider _tempDataProvider;
    private readonly IServiceProvider _serviceProvider;

    public IndexModel(IHubContext<MessageHub> messageHubContext, IRazorViewEngine viewEngine, ITempDataProvider tempDataProvider, IServiceProvider serviceProvider)
    {
        _messageHubContext = messageHubContext;
        _viewEngine = viewEngine;
        _tempDataProvider = tempDataProvider;
        _serviceProvider = serviceProvider;
    }

    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost(string msg)
    {
        var html = await RenderViewToStringAsync<(string message, bool includeOob, DateTimeOffset serverTime)>("/Pages/SignalR/_Message.cshtml", (msg, true, DateTimeOffset.Now));

        await _messageHubContext.Clients.All.SendAsync("spam", html);

        return Partial("_Form");
    }


    private async Task<string> RenderViewToStringAsync<TModel>(string viewPath, TModel model)
    {
        var actionContext = new ActionContext(new DefaultHttpContext { RequestServices = _serviceProvider }, new RouteData(), new ActionDescriptor());

        using (var sw = new StringWriter())
        {
            var viewResult = _viewEngine.GetView(null, viewPath, false);

            if (viewResult.View == null)
            {
                throw new ArgumentNullException($"{viewPath} not found");
            }

            var viewDictionary = new ViewDataDictionary(new EmptyModelMetadataProvider(), new ModelStateDictionary())
            {
                Model = model
            };

            var viewContext = new ViewContext(
                actionContext,
                viewResult.View,
                viewDictionary,
                new TempDataDictionary(actionContext.HttpContext, _tempDataProvider),
                sw,
                new HtmlHelperOptions()
            );

            await viewResult.View.RenderAsync(viewContext);
            return sw.ToString();
        }
    }
}