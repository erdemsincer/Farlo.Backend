using Farlo.History.Domain.Entities;

namespace Farlo.History.Application.Interfaces;

public interface IHistoryRepository
{
    Task SaveAsync(GeoQueryHistory history);
    Task<List<GeoQueryHistory>> GetAllAsync();
}
