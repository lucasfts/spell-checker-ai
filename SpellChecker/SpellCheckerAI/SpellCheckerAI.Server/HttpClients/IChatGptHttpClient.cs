using Refit;
using SpellCheckerAI.Server.Models.CreateChatCompletion;

namespace SpellCheckerAI.Server.HttpClients
{
    public interface IChatGptHttpClient
    {
        [Post("/v1/chat/completions")]
        Task<CreateChatCompletionResponse> CreateChatCompletion(CreateChatCompletionRequest request);
    }
}
