using Farlo.Insight.Application.Interfaces;
using Farlo.Insight.Domain.Entities;
using Farlo.Insight.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Farlo.Insight.Infrastructure.Repositories;

public class InMemoryInsightRepository : IInsightRepository
{
    private readonly InsightDbContext _context;

    public InMemoryInsightRepository(InsightDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(Domain.Entities.Insight insight)
    {
        await _context.Insights.AddAsync(insight);
        await _context.SaveChangesAsync();
    }

    public async Task<List<Domain.Entities.Insight>> GetAllAsync()
    {
        return await _context.Insights.ToListAsync();
    }
}
