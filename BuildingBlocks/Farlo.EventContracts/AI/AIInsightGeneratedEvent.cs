namespace Farlo.EventContracts.AI;

public record AIInsightGeneratedEvent(
    string RequestId,
    string InsightSummary
);
