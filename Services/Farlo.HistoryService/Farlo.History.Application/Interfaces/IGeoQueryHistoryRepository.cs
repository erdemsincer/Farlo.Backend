using Farlo.History.Domain.Entities;

namespace Farlo.History.Application.Interfaces;

public interface IGeoQueryHistoryRepository
{
    Task<GeoQueryHistory?> GetByCoordinatesAsync(double lat, double lon);
    Task SaveAsync(GeoQueryHistory history);
}
