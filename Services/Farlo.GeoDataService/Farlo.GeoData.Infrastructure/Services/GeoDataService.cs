using Farlo.GeoData.Application.Interfaces;

namespace Farlo.GeoData.Infrastructure.Services;

public class GeoDataService : IGeoDataService
{
    public Task<(string Climate, string Vegetation, string Elevation)> GetGeoDataAsync(double latitude, double longitude)
    {
        
        return Task.FromResult((
            "Karasal iklim",
            "Bozkır",
            "1045m"
        ));
    }
}
