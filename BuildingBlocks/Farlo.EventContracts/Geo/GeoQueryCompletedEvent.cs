namespace Farlo.EventContracts.Geo;

public record GeoQueryCompletedEvent(
    string RequestId,
    string Climate,
    string Vegetation,
    string Elevation
);
