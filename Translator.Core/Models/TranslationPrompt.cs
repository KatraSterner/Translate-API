namespace Translator.Core.Models;

public class TranslationPrompt
{
    // This model is for collecting the data sent from the user with the front-end
    // it is sent to the api and broken down from there
    public string Prompt { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
}