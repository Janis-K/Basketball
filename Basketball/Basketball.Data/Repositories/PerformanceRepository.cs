using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class PerformanceRepository : RepositoryBase<Performance>, IPerformanceRepository
    {
        public PerformanceRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPerformanceRepository : IRepository<Performance> { }
}
