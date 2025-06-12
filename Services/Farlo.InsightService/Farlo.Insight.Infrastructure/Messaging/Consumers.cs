using Farlo.EventContracts.AI;
using Farlo.Insight.Application.Interfaces;
using MassTransit;

namespace Farlo.Insight.Infrastructure.Messaging.Consumers;

public class AIInsightGeneratedConsumer : IConsumer<AIInsightGeneratedEvent>
{
    private readonly IInsightRepository _repository;

    public AIInsightGeneratedConsumer(IInsightRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<AIInsightGeneratedEvent> context)
    {
        await _repository.SaveAsync(new()
        {
            Id = Guid.NewGuid(),
            RequestId = context.Message.RequestId,
            Summary = context.Message.InsightSummary,
            CreatedAt = DateTime.UtcNow
        });
    }
}
