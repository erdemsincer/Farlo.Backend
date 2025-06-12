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
}
