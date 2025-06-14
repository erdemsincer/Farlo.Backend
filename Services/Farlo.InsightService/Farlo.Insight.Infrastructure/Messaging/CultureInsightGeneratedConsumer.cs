using Farlo.EventContracts.Culture;
using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Domain.Entities;
using MassTransit;

namespace Farlo.Insight.Infrastructure.Messaging.Consumers;

public class CultureInsightGeneratedConsumer : IConsumer<CultureInsightGeneratedEvent>
{
    private readonly IInsightRepository _repository;

    public CultureInsightGeneratedConsumer(IInsightRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<CultureInsightGeneratedEvent> context)
    {
        var m = context.Message;

        await _repository.SaveCultureInsightAsync(new CultureInsight
        {
            Id = Guid.NewGuid(),
            RequestId = m.RequestId,
            Latitude = m.Latitude,
            Longitude = m.Longitude,
            Summary = m.Summary,
            CreatedAt = DateTime.UtcNow
        });
    }
}
