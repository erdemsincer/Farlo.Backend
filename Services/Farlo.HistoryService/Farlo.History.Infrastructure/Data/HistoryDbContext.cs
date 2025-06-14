using Farlo.History.Domain.Entities;
using MassTransit;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Farlo.History.Infrastructure.Data;

public class HistoryDbContext : DbContext
{
    public HistoryDbContext(DbContextOptions<HistoryDbContext> options) : base(options) { }

    public DbSet<GeoQueryHistory> GeoQueryHistories => Set<GeoQueryHistory>();
}
