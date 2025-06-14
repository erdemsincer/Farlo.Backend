using Farlo.History.Application.Interfaces;
using Farlo.History.Domain.Entities;

namespace Farlo.History.Infrastructure.Repositories;

public class InMemoryGeoQueryHistoryRepository : IGeoQueryHistoryRepository
{
    private static readonly List<GeoQueryHistory> _storage = new();

    public Task<GeoQueryHistory?> GetByCoordinatesAsync(double lat, double lon)
    {
        var match = _storage.FirstOrDefault(h =>
            Math.Abs(h.Latitude - lat) < 0.0001 &&
            Math.Abs(h.Longitude - lon) < 0.0001);

        return Task.FromResult(match);
    }

    public Task SaveAsync(GeoQueryHistory history)
    {
        _storage.Add(history);
        return Task.CompletedTask;
    }
}
