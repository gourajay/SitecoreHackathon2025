using Sitecore.Mvc.Controllers;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

public class ItemCreateController : SitecoreController
{
    [HttpPost]
    public async Task<ActionResult> GenerateScript([FromBody] HeroBannerRequest request)
    {
        // Call the ChatGPT API to generate the PowerShell script
        var scriptService = new ChatGptService();
        var script = await scriptService.GetChatGptResponseAsync(request.Message);

        // Log the received script (optional)
        Sitecore.Diagnostics.Log.Info($"Generated PowerShell Script: {script}", this);

        // Call a service to execute the PowerShell script
        var sitecoreItemService = new SitecoreItemService();
        sitecoreItemService.ExecutePowerShellScript(script);

        return Json(new { success = true, script });
    }
}
