using Farlo.EventContracts.Geo;
using Farlo.EventContracts.AI;
using Farlo.EventContracts.Culture;
using Farlo.AI.Application.Interfaces;
using MassTransit;

namespace Farlo.AI.Infrastructure.Messaging.Consumers;

public class GeoQueryCompletedConsumer : IConsumer<GeoQueryCompletedEvent>
{
    private readonly IAIService _aiService;
    private readonly IPublishEndpoint _publishEndpoint;

    public GeoQueryCompletedConsumer(IAIService aiService, IPublishEndpoint publishEndpoint)
    {
        _aiService = aiService;
        _publishEndpoint = publishEndpoint;
    }

    public async Task Consume(ConsumeContext<GeoQueryCompletedEvent> context)
    {
        var message = context.Message;

        var generalInsight = await _aiService.GenerateInsightAsync(message);
        await _publishEndpoint.Publish(new AIInsightGeneratedEvent(
            message.RequestId,
            generalInsight
        ));

        var cultureInsight = await _aiService.GenerateCultureInsightAsync(message);
        await _publishEndpoint.Publish(new CultureInsightGeneratedEvent(
            message.RequestId,
            message.Latitude,
            message.Longitude,
            cultureInsight
        ));
    }
}

