using Farlo.EventContracts.AI;
using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Domain.Entities;
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
        var message = context.Message;

        await _repository.SaveAIInsightAsync(new Domain.Entities.Insight
        {
            Id = Guid.NewGuid(),
            RequestId = message.RequestId,
            Summary = message.InsightSummary,
            CreatedAt = DateTime.UtcNow
        });
    }
}
