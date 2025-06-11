using Farlo.EventContracts.Geo;
using MassTransit;

namespace Farlo.GeoData.Infrastructure.Messaging.Consumers;

public class GeoQueryRequestedConsumer : IConsumer<GeoQueryRequestedEvent>
{
    private readonly IPublishEndpoint _publishEndpoint;

    public GeoQueryRequestedConsumer(IPublishEndpoint publishEndpoint)
    {
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<GeoQueryRequestedEvent> context)
    {
        var message = context.Message;

        // 🌍 Mock coğrafi veriler (ileride dış API veya DB'den alınacak)
        var climate = "Karasal iklim";
        var vegetation = "Bozkır";
        var elevation = "1045m";

        var responseEvent = new GeoQueryCompletedEvent(
            message.RequestId,
            climate,
            vegetation,
            elevation
        );

        await _publishEndpoint.Publish(responseEvent);
    }
}
