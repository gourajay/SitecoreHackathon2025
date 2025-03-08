using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using Sitecore;
using Sitecore.Shell.Framework.Commands;
using Sitecore.Text;
using Sitecore.Web.UI.Sheer;
using Sitecore.Web.UI.Xaml;

namespace SitecoreHackathon.Commands
{
    [HttpPost]
    public ActionResult SendMessage(string query)
    {
        if (string.IsNullOrWhiteSpace(query))
        {
            return RedirectToAction("Index"); // Ignore empty messages
        }

        // Retrieve previous messages from session
        var messages = (List<string>)Session["ChatMessages"] ?? new List<string>();

        // Simulated AI Response (Replace with actual Gemini API call)
        string response = $"You said: {query}. This is Gemini's response!";

        // Add user and AI messages to the chat history
        messages.Add($"<b>You:</b> {query}");
        messages.Add($"<b>Gemini:</b> {response}");

        // Save back to session
        Session["ChatMessages"] = messages;

        return RedirectToAction("Index"); // Reload the chat
    }

    public ActionResult Index()
    {
        return View();
    }

    public ActionResult ChatHistory()
    {
        return PartialView("_ChatMessage");
    }

    public class FridayAI : Command
    {
        public override void Execute(CommandContext context)
        {
            Sitecore.Context.ClientPage.Start(this, "Run", context.Parameters);
        }

        protected static void Run(ClientPipelineArgs args)
        {
            if (!args.IsPostBack)
            {
                HttpContext.Current.Response.Redirect("/Index");
            }
        }
    }
}
