using Farlo.EventContracts.Geo;
using Farlo.EventContracts.AI;
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
        var insight = await _aiService.GenerateInsightAsync(context.Message);

        await _publishEndpoint.Publish(new AIInsightGeneratedEvent(
            context.Message.RequestId,
            insight
        ));
    }
}
