using Farlo.Insight.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farlo.Insight.API.Controllers;

[ApiController]
[Route("api/insight")]
public class InsightController : ControllerBase
{
    private readonly IInsightRepository _repository;

    public InsightController(IInsightRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("ai")]
    public async Task<IActionResult> GetAIInsights()
    {
        var data = await _repository.GetAllAIInsightsAsync();
        return Ok(data);
    }

    [HttpGet("culture")]
    public async Task<IActionResult> GetCultureInsights()
    {
        var data = await _repository.GetAllCultureInsightsAsync();
        return Ok(data);
    }
}
