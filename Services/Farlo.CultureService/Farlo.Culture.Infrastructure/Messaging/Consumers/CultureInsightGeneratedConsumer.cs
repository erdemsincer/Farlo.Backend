using Farlo.Culture.Application.Interfaces;
using Farlo.Culture.Domain.Entities;
using Farlo.EventContracts.Culture;
using MassTransit;

namespace Farlo.Culture.Infrastructure.Messaging.Consumers;

public class CultureInsightGeneratedConsumer : IConsumer<CultureInsightGeneratedEvent>
{
    private readonly IInsightRepository _insightRepository;

    public CultureInsightGeneratedConsumer(IInsightRepository insightRepository)
    {
        _insightRepository = insightRepository;
    }

    public async Task Consume(ConsumeContext<CultureInsightGeneratedEvent> context)
    {
        var message = context.Message;

        var insight = new CultureInsight
        {
            RequestId = message.RequestId,
            Latitude = message.Latitude,
            Longitude = message.Longitude,
            Summary = message.Summary,
            CreatedAt = DateTime.UtcNow
        };

        await _insightRepository.SaveAsync(insight);
    }
}
