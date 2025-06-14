namespace Farlo.EventContracts.Culture;

public record CultureInsightGeneratedEvent(
    string RequestId,
    double Latitude,
    double Longitude,
    string Summary
);
