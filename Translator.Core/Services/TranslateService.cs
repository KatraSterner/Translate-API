using GTranslate.Translators;
using Translator.Core.Models;

namespace Translator.Core.Services;

public class TranslateService
{
    // this layer contains business logic and accesses the NuGet package's methods
    public async Task<string> GetTranslation(TranslationPrompt prompt)
    {
        // check if the prompt from the controller is empty (should be impossible because input field is required)
        if (string.IsNullOrEmpty(prompt.Prompt))
        {
            // if empty return this as the result
            return "No text provided.";
        }
        
        // access the GTranslate NuGet package by making an instance
        var translator = new GoogleTranslator();
        // use the instance by passing in the prompt and target language and save the result
        var result = await translator.TranslateAsync(prompt.Prompt, prompt.TargetLanguage);
        
        // return the translated prompt back to the controller
        return result.Translation;
    }
}