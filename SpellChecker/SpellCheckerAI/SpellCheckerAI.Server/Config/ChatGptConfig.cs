using Refit;
using SpellCheckerAI.Server.HttpClients;
using System.Net.Http.Headers;

namespace SpellCheckerAI.Server.Config
{
    public class ChatGptConfig
    {
        public string ApiUrl { get; set; }
        public string ApiSecret { get; set; }
    }

    public static class ChatGptConfigExtensions
    {
        public static void AddChatGptHttpClient(this IServiceCollection services, IConfiguration configuration)
        {
            var chatGptConfig = configuration.GetSection("ChatGpt").Get<ChatGptConfig>();

            services
                .AddRefitClient<IChatGptHttpClient>()
                .ConfigureHttpClient(client =>
                {
                    var chatGptConfig = configuration.GetSection("ChatGpt").Get<ChatGptConfig>();
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", chatGptConfig.ApiSecret);
                    client.BaseAddress = new Uri(chatGptConfig.ApiUrl);
                });
        }
    }
}
