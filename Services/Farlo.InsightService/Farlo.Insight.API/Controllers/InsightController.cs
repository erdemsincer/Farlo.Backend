using Farlo.Insight.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farlo.Insight.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class InsightController : ControllerBase
{
    private readonly IInsightRepository _repository;

    public InsightController(IInsightRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var insights = await _repository.GetAllAsync();
        return Ok(insights);
    }
    [HttpGet("{requestId}")]
    public async Task<IActionResult> GetByRequestId(string requestId)
    {
        var insights = await _repository.GetAllAsync();
        var result = insights.FirstOrDefault(x => x.RequestId == requestId);

        if (result is null)
            return NotFound(new { message = "No insight found for the given RequestId" });

        return Ok(result);
    }
}
