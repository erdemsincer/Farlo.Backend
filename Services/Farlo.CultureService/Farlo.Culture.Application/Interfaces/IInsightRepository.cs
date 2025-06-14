using Farlo.Culture.Domain.Entities;

namespace Farlo.Culture.Application.Interfaces;

public interface IInsightRepository
{
    Task SaveAsync(CultureInsight insight);
    Task<List<CultureInsight>> GetAllAsync();
}
