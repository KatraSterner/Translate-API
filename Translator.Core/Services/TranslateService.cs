namespace Translator.Core.Services;

public class TranslateService
{
    public string TranslatePrompt(string prompt)
    {
        if (string.IsNullOrEmpty(prompt))
        {
            return "No text provided.";
        }
        
        // TODO: implement NuGet package to translate prompt here!!!!!!!!!

        return "Translated text placeholder...";
    }
}