using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Farlo.Insight.Domain.Repositories
{
    public interface ICultureInsightRepository
    {
        Task SaveAsync(Domain.Entities.CultureInsight insight);
        Task<List<Domain.Entities.CultureInsight>> GetAllAsync();
    }
}
