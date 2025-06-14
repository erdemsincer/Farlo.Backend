using Farlo.EventContracts.Geo;

namespace Farlo.AI.Application.Interfaces;

public interface IAIService
{
    Task<string> GenerateInsightAsync(GeoQueryCompletedEvent data);
    Task<string> GenerateCultureInsightAsync(GeoQueryCompletedEvent geoData);
}
