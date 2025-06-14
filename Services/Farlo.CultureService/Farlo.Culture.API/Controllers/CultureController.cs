using Farlo.Culture.Application.Interfaces;
using Farlo.Culture.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Farlo.Culture.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CultureController : ControllerBase
{
    private readonly IInsightRepository _insightRepository;

    public CultureController(IInsightRepository insightRepository)
    {
        _insightRepository = insightRepository;
    }

    [HttpGet("insights")]
    public async Task<IActionResult> GetAll()
    {
        var insights = await _insightRepository.GetAllAsync();
        return Ok(insights);
    }

    [HttpPost("generate")]
    public async Task<IActionResult> SaveInsight([FromBody] CultureInsight insight)
    {
        await _insightRepository.SaveAsync(insight);
        return Ok(new { message = "Culture insight saved successfully." });
    }
}
