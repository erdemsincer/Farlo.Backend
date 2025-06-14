using Farlo.EventContracts.Geo;
using Farlo.GeoData.Application.Interfaces;
using MassTransit;

namespace Farlo.GeoData.Infrastructure.Messaging.Consumers;

public class GeoQueryRequestedConsumer : IConsumer<GeoQueryRequestedEvent>
{
    private readonly IGeoDataService _geoDataService;
    private readonly IPublishEndpoint _publishEndpoint;

    public GeoQueryRequestedConsumer(IGeoDataService geoDataService, IPublishEndpoint publishEndpoint)
    {
        _geoDataService = geoDataService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<GeoQueryRequestedEvent> context)
    {
        var message = context.Message;

        var (climate, vegetation, elevation) =
            await _geoDataService.GetGeoDataAsync(message.Latitude, message.Longitude);

        await _publishEndpoint.Publish(new GeoQueryCompletedEvent(
            message.RequestId,
            message.Latitude,
            message.Longitude,
            climate,
            vegetation,
            elevation
        )); 
    }
}
