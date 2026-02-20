using Microsoft.SemanticKernel;

namespace SchoolERP.Services
{
    public class SmartAssistantService
    {
        private readonly Kernel _kernel;

        public SmartAssistantService(IConfiguration config)
        {
            // Initialize the Semantic Kernel builder
            var builder = Kernel.CreateBuilder();
            
            // Connect to Gemini using your secure local secret
            builder.AddGoogleAIGeminiChatCompletion(
                modelId: "gemini-2.5-flash", // Updated to the active 2026 model
                apiKey: config["AI:ApiKey"] ?? throw new InvalidOperationException("API Key missing")
            );
            
            _kernel = builder.Build();
        }

        public async Task<string> GenerateInsightAsync(string prompt)
        {
            // The kernel processes the prompt and returns the AI's response
            var response = await _kernel.InvokePromptAsync(prompt);
            return response.ToString();
        }
    }
}