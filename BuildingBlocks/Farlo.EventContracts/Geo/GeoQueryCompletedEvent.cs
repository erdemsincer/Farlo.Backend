namespace Farlo.EventContracts.Geo;

public record GeoQueryCompletedEvent(
    string RequestId,
    double Latitude,
    double Longitude,
    string Climate,
    string Vegetation,
    string Elevation
);
