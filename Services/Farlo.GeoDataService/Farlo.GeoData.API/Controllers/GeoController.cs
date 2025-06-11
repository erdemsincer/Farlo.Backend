using Farlo.EventContracts.Geo;
using Farlo.GeoData.Application.DTOs;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Farlo.GeoData.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GeoController : ControllerBase
{
    private readonly IPublishEndpoint _publishEndpoint;

    public GeoController(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    [HttpPost("query")]
    public async Task<IActionResult> PublishGeoQuery([FromBody] GeoQueryRequestDto dto)
    {
        var requestId = Guid.NewGuid().ToString();

        await _publishEndpoint.Publish(new GeoQueryRequestedEvent(
            requestId,
            dto.Latitude,
            dto.Longitude
        ));

        return Ok(new { Message = "Event published", RequestId = requestId });
    }
}
