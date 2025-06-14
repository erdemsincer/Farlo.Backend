using Farlo.Culture.Application.Interfaces;
using Farlo.Culture.Domain.Entities;
using Farlo.Culture.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Farlo.Culture.Infrastructure.Repositories;

public class EFInsightRepository : IInsightRepository
{
    private readonly CultureDbContext _context;

    public EFInsightRepository(CultureDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(CultureInsight insight)
    {
        _context.CultureInsights.Add(insight);
        await _context.SaveChangesAsync();
    }

    public async Task<List<CultureInsight>> GetAllAsync()
    {
        return await _context.CultureInsights
            .OrderByDescending(x => x.CreatedAt)
            .ToListAsync();
    }
}
