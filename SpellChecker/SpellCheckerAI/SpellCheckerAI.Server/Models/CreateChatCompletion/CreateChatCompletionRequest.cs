namespace SpellCheckerAI.Server.Models.CreateChatCompletion
{
    public class CreateChatCompletionRequest
    {
        public CreateChatCompletionRequest(string systemMessage, string userMessage)
        {
            Model = "gpt-3.5-turbo";
            Messages = [
                new ChatGptMessage { Role = "system", Content = systemMessage },
                new ChatGptMessage { Role = "user", Content = userMessage }
            ];
        }

        public string Model { get; set; }
        public ChatGptMessage[] Messages { get; set; }
    }

    public class ChatGptMessage
    {
        public string Role { get; set; }
        public string Content { get; set; }
    }

}
