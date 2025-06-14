using Farlo.EventContracts.Geo;
using Farlo.History.Application.Interfaces;
using Farlo.History.Domain.Entities;
using MassTransit;

namespace Farlo.History.Infrastructure.Messaging.Consumers;

public class GeoQueryCompletedConsumer : IConsumer<GeoQueryCompletedEvent>
{
    private readonly IHistoryRepository _repository;

    public GeoQueryCompletedConsumer(IHistoryRepository repository)
    {
        _repository = repository;
    }

    public async Task Consume(ConsumeContext<GeoQueryCompletedEvent> context)
    {
        var message = context.Message;

        var history = new GeoQueryHistory
        {
            RequestId = message.RequestId,
            Latitude = message.Latitude,
            Longitude = message.Longitude,
            CreatedAt = DateTime.UtcNow
        };

        await _repository.SaveAsync(history);
    }
}
