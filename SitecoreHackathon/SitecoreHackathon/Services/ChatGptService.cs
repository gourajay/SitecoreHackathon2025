using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

public class ChatGptService
{
	private readonly HttpClient _httpClient;
	private readonly string _apiKey = "sk-abcdef1234567890abcdef1234567890abcdef12"; // Your OpenAI API key

	public ChatGptService()
	{
		_httpClient = new HttpClient();
	}

	public async Task<string> GetChatGptResponseAsync(string query)
	{
		var requestBody = new
		{
			model = "gpt-4",  // Or gpt-3.5
			messages = new[]
			{
				new { role = "user", content = query }
			}
		};

		var content = new StringContent(JsonConvert.SerializeObject(requestBody), Encoding.UTF8, "application/json");
		_httpClient.DefaultRequestHeaders.Add("Authorization", $"Bearer {_apiKey}");

		var response = await _httpClient.PostAsync("https://api.openai.com/v1/chat/completions", content);
		var responseString = await response.Content.ReadAsStringAsync();

		// Parse the response and return the PowerShell script
		var responseJson = JsonConvert.DeserializeObject<dynamic>(responseString);
		return responseJson.choices[0].message.content;
	}
}
