using Farlo.GeoData.Application.Interfaces;
using System.Text.Json;

namespace Farlo.GeoData.Infrastructure.Services;

public class GeoDataService : IGeoDataService
{
    private readonly HttpClient _httpClient;

    public GeoDataService()
    {
        _httpClient = new HttpClient();
    }

    public async Task<(string Climate, string Vegetation, string Elevation)> GetGeoDataAsync(double latitude, double longitude)
    {
        string elevation = "Bilinmiyor";

        try
        {
            var url = $"https://api.opentopodata.org/v1/test-dataset?locations={latitude},{longitude}";
            var response = await _httpClient.GetAsync(url);

            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                using var doc = JsonDocument.Parse(json);
                var elevationValue = doc.RootElement
                    .GetProperty("results")[0]
                    .GetProperty("elevation")
                    .GetRawText();

                elevation = $"{elevationValue}m";
            }
        }
        catch
        {
            elevation = "Veri alınamadı";
        }

        return (
            "Karasal iklim",   // İleride Open-Meteo ile bağlanacağız
            "Bozkır",          // İleride AI tahmini veya Natural Earth verisi ile
            elevation
        );
    }
}
