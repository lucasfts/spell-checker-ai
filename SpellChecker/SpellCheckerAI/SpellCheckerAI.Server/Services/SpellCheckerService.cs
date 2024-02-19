using SpellCheckerAI.Server.HttpClients;
using SpellCheckerAI.Server.Models.CreateChatCompletion;
using SpellCheckerAI.Server.Models.SpellCheck;
using System.Text.Json;

namespace SpellCheckerAI.Server.Services
{
    public interface ISpellCheckerService
    {
        Task<SpellCheckResponse> GetSpellCheck(string text);
    }

    public class SpellCheckerService : ISpellCheckerService
    {
        private readonly IChatGptHttpClient _chatGptClient;

        public SpellCheckerService(IChatGptHttpClient chatGptClient)
        {
            _chatGptClient = chatGptClient;
        }

        public async Task<SpellCheckResponse> GetSpellCheck(string text)
        {
            var systemMessage = "Check the spelling of the sentence entered by the user. " +
            "Returns this in a json object with the properties 'isValid' and 'feedback'." +
            "The 'isValid' property is boolean with the value true if the sentence is correct or false if not." +
            "The 'isValid' property is a string that explains if the sentence is correct " +
            "or what is the correct sentence and why the sentence entered by the user was wrong.";

            var request = new CreateChatCompletionRequest(systemMessage, text);
            var chatCompletion = await _chatGptClient.CreateChatCompletion(request);

            var chatCompletionMessage = chatCompletion.Choices.First().Message.Content;
            var result = JsonSerializer.Deserialize<SpellCheckResponse>(chatCompletionMessage);
            return result;
        }
    }
}
