using Farlo.History.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Farlo.History.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class HistoryController : ControllerBase
{
    private readonly IHistoryRepository _repository;

    public HistoryController(IHistoryRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var all = await _repository.GetAllAsync();
        return Ok(all);
    }
}
