using System.Text.Json.Serialization;

namespace SpellCheckerAI.Server.Models.SpellCheck
{
    public class SpellCheckResponse
    {
        [JsonPropertyName("isValid")]
        public bool IsValid { get; set; }

        [JsonPropertyName("feedback")]
        public string Feedback { get; set; }
    }
}
