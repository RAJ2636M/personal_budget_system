using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;

namespace personal_budget_system
{
    public class OllamaService
    {
        private readonly HttpClient client;

        public OllamaService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:11434/");
        }

        public async Task<string> GetBudgetAdvice(string prompt)
        {
            string json = "{"
                + "\"model\":\"gemma3:1b\","
                + "\"prompt\":\"" + EscapeJson(prompt) + "\","
                + "\"stream\":false"
                + "}";

            StringContent content = new StringContent(
                json,
                Encoding.UTF8,
                "application/json"
            );

            HttpResponseMessage response =
                await client.PostAsync("api/generate", content);

            string result = await response.Content.ReadAsStringAsync();

            if (!response.IsSuccessStatusCode)
            {
                return "AI service error: " + result;
            }

            JavaScriptSerializer serializer =
                new JavaScriptSerializer();

            Dictionary<string, object> data =
                serializer.Deserialize<Dictionary<string, object>>(result);

            if (data.ContainsKey("response"))
            {
                return data["response"].ToString();
            }

            return "Unable to read AI response.";
        }

        private string EscapeJson(string text)
        {
            return text
                .Replace("\\", "\\\\")
                .Replace("\"", "\\\"")
                .Replace("\r", "")
                .Replace("\n", "\\n");
        }
    }
}