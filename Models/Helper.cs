using System.Text;

namespace WebApplication14.Models
{
    public class Helper
    {
        public static async Task SendEmailAsync(string to, string subject, string html)
        {
            var apiKey = Environment.GetEnvironmentVariable("RESEND_API_KEY");

            using var client = new HttpClient();
            client.DefaultRequestHeaders.Add("Authorization", $"Bearer {apiKey}");

            var payload = new
            {
                from = "onboarding@resend.dev",
                to = new[] { Environment.GetEnvironmentVariable("TO") },
                subject = subject,
                html = html
            };

            var content = new StringContent(
                System.Text.Json.JsonSerializer.Serialize(payload),
                Encoding.UTF8,
                "application/json"
            );

            var response = await client.PostAsync("https://api.resend.com/emails", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
