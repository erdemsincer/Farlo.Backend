using Farlo.Insight.Domain.Entities;

namespace Farlo.Insight.Application.Interfaces;

public interface IInsightRepository
{
    Task SaveAsync(Domain.Entities.Insight insight);
    Task<List<Domain.Entities.Insight>> GetAllAsync();
}
