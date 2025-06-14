using Farlo.History.Application.Interfaces;
using Farlo.History.Domain.Entities;
using Farlo.History.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Farlo.History.Infrastructure.Repositories;

public class PostgresHistoryRepository : IHistoryRepository
{
    private readonly HistoryDbContext _context;

    public PostgresHistoryRepository(HistoryDbContext context)
    {
        _context = context;
    }

    public async Task SaveAsync(GeoQueryHistory history)
    {
        _context.GeoQueryHistories.Add(history);
        await _context.SaveChangesAsync();
    }

    public async Task<List<GeoQueryHistory>> GetAllAsync()
    {
        return await _context.GeoQueryHistories
            .OrderByDescending(h => h.CreatedAt)
            .ToListAsync();
    }
}
