using GTranslate.Translators;
using Translator.Core.Models;

namespace Translator.Core.Services;

public class TranslateService
{
    public async Task<string> GetTranslation(TranslationPrompt prompt)
    {
        if (string.IsNullOrEmpty(prompt.Prompt))
        {
            return "No text provided.";
        }
        
        var translator = new GoogleTranslator();
        var result = await translator.TranslateAsync(prompt.Prompt, prompt.TargetLanguage);

        return result.Translation;
    }
}