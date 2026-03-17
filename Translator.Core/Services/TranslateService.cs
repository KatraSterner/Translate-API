using Translator.Core.Models;

namespace Translator.Core.Services;

public class TranslateService
{
    public string TranslatePrompt(TranslationPrompt prompt)
    {
        if (string.IsNullOrEmpty(prompt.Prompt))
        {
            return "No text provided.";
        }
        
        // TODO: implement NuGet package to translate prompt here!!!!!!!!!

        return "Translated text placeholder...";
    }
}