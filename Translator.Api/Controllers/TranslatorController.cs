using Microsoft.AspNetCore.Mvc;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/translate")]
public class TranslatorController(TranslateService translateService) : ControllerBase
{
    // this controller only has one endpoint because there is just one main feature
    [HttpPost]
    public async Task<ActionResult<TranslationDTO>> Translate([FromBody] TranslationPrompt translationPrompt)
    {
        // check that the entered prompt is not empty (should be impossible because input field is required)
        if (string.IsNullOrEmpty(translationPrompt.Prompt))
        {
            // if empty replace with this prompt
            translationPrompt.Prompt = "prompt cannot be translated if it is empty...";
        }
        
        // set up a DTO with the translated prompt
        var response = new TranslationDTO
        {
            Prompt = translationPrompt.Prompt,
            Translation = await translateService.GetTranslation(translationPrompt)
        };
        
        // if the DTO has no errors return the JSON data to the localhost endpoint url
        return Ok(response);
    }
}