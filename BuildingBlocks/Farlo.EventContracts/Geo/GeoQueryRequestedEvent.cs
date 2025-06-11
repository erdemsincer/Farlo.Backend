namespace Farlo.EventContracts.Geo;

public record GeoQueryRequestedEvent(
    string RequestId,
    double Latitude,
    double Longitude
);
