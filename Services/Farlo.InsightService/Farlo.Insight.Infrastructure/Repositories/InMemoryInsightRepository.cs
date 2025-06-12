using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Domain.Entities;

namespace Farlo.Insight.Infrastructure.Repositories;

public class InMemoryInsightRepository : IInsightRepository
{
    private static readonly List<Domain.Entities.Insight> _storage = new();

    public Task SaveAsync(Domain.Entities.Insight insight)
    {
        _storage.Add(insight);
        return Task.CompletedTask;
    }

    public Task<List<Domain.Entities.Insight>> GetAllAsync()
    {
        return Task.FromResult(_storage);
    }
}
