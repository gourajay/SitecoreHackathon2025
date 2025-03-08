using System.Collections.Generic;
using System.Web.Mvc;

public class ChatController : Controller
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
}
