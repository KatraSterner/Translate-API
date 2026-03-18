namespace Translator.Core.Models;

public class TranslationDTO
{
    // This DTO is used to return data to the front-end and display to the UI
    public string Prompt { get; set; } = string.Empty;
    public string Translation { get; set; } = string.Empty;
}