using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class PositionRepository : RepositoryBase<Position>, IPositionRepository
    {
        public PositionRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface IPositionRepository : IRepository<Position> { }
}
