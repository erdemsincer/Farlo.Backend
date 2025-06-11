namespace Farlo.GeoData.Application.Interfaces;

public interface IGeoDataService
{
    Task<(string Climate, string Vegetation, string Elevation)> GetGeoDataAsync(double latitude, double longitude);
}
