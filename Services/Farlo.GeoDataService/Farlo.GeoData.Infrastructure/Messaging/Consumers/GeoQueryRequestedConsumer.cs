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
        var (climate, vegetation, elevation) =
            await _geoDataService.GetGeoDataAsync(context.Message.Latitude, context.Message.Longitude);

        await _publishEndpoint.Publish(new GeoQueryCompletedEvent(
            context.Message.RequestId,
            climate,
            vegetation,
            elevation
        ));
    }
}
