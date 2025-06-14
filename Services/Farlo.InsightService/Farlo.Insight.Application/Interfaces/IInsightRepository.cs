namespace Farlo.Insight.Application.Interfaces
{
    public interface IInsightRepository
    {
        Task SaveAIInsightAsync(Domain.Entities.Insight insight);
        Task<IEnumerable<Domain.Entities.Insight>> GetAllAIInsightsAsync();

        Task SaveCultureInsightAsync(Domain.Entities.CultureInsight insight);
        Task<IEnumerable<Domain.Entities.CultureInsight>> GetAllCultureInsightsAsync();
    }
}
