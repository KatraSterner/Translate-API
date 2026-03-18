using Microsoft.AspNetCore.Mvc;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/translate")]
public class TranslatorController(TranslateService translateService) : ControllerBase
{
    [HttpPost]
    public async Task<ActionResult<TranslationDTO>> Translate([FromBody] TranslationPrompt translationPrompt)
    {
        Console.WriteLine("-----------------------------------------------");
        Console.WriteLine($"Prompt: {translationPrompt.Prompt}");
        Console.WriteLine($"TargetLanguage: {translationPrompt.TargetLanguage}");
        
        if (string.IsNullOrEmpty(translationPrompt.Prompt))
        {
            translationPrompt.Prompt = "prompt cannot be translated if it is empty...";
        }
        
        var response = new TranslationDTO
        {
            Prompt = translationPrompt.Prompt,
            Translation = await translateService.GetTranslation(translationPrompt)
        };
        
        return Ok(response);
    }
}