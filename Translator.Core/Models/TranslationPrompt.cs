namespace Translator.Core.Models;

public class TranslationPrompt
{
    public string Prompt { get; set; } = string.Empty;
    public string TargetLanguage { get; set; } = string.Empty;
}