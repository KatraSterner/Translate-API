using Microsoft.AspNetCore.Mvc;
using Translator.Core.Models;
using Translator.Core.Services;

namespace Translator.Api.Controllers;

[ApiController]
[Route("api/translate")]
public class TranslatorController(TranslateService translateService) : ControllerBase
{
    [HttpPost]
    public ActionResult<Message> Translate([FromBody] string prompt)
    {
        if (string.IsNullOrWhiteSpace(prompt))
        {
            return BadRequest("prompt cannot be translated if it is empty...");
        }

        var response = new Message
        {
            Prompt = prompt,
            Translation = translateService.TranslatePrompt(prompt)
        };
        
        return Ok(response);
    }
}