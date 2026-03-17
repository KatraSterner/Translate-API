using Microsoft.AspNetCore.Mvc;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/translate")]
public class TranslatorController(TranslateService translateService) : ControllerBase
{
    [HttpPost]
    public ActionResult<TranslationDTO> Translate([FromBody] TranslationPrompt prompt)
    {
        if (string.IsNullOrEmpty(prompt.Prompt))
        {
            prompt.Prompt = "prompt cannot be translated if it is empty...";
        }

        var response = new TranslationDTO
        {
            Prompt = prompt.Prompt,
            Translation = translateService.TranslatePrompt(prompt)
        };
        
        return Ok(response);
    }
}