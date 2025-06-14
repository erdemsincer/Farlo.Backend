namespace Farlo.Insight.Domain.Repositories
{
    public interface IInsightRepository
    {
        Task SaveAsync(Domain.Entities.Insight insight);
        Task<List<Domain.Entities.Insight>> GetAllAsync();
    }
}
