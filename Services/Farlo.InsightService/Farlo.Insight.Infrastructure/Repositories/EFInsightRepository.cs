using Farlo.Culture.Domain.Entities;
using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Domain.Entities;
using Farlo.Insight.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Farlo.Insight.Infrastructure.Repositories
{
    public class EFInsightRepository : IInsightRepository
    {
        private readonly InsightDbContext _context;

        public EFInsightRepository(InsightDbContext context)
        {
            _context = context;
        }

        public async Task SaveAIInsightAsync(Domain.Entities.Insight insight)
        {
            _context.AIInsights.Add(insight);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.Insight>> GetAllAIInsightsAsync()
        {
            return await _context.AIInsights
                                 .OrderByDescending(x => x.CreatedAt)
                                 .ToListAsync();
        }

        public async Task SaveCultureInsightAsync(Domain.Entities.CultureInsight insight)
        {
            _context.CultureInsights.Add(insight);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Domain.Entities.CultureInsight>> GetAllCultureInsightsAsync()
        {
            return await _context.CultureInsights
                                 .OrderByDescending(x => x.CreatedAt)
                                 .ToListAsync();
        }
    }
}
