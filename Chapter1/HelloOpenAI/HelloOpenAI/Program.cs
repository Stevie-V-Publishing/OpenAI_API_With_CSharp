using System;
using System.Net.Http.Json;
using System.Net.Http;
using System.Text;

namespace HelloOpenAI
{
	class Program
	{
		static void Main(string[] args)
		{			
			var key = "Your key goes here";
			var requestJson = "{\"model\": \"gpt-4o\", \"messages\": [{\"role\": \"user\", \"content\": \"Hello World!\" } ] }";
			var apiUrl = "https://api.openai.com/v1/chat/completions";

			using (var client  = new HttpClient()) 
			{
				client.DefaultRequestHeaders.Add("Authorization", $"Bearer {key}");

				HttpContent content = new StringContent(requestJson, Encoding.UTF8, "application/json");
				HttpResponseMessage response = client.PostAsync(apiUrl, content).Result;

				Console.Write(response.Content.ReadAsStringAsync().Result);

			}
		}
	}
}