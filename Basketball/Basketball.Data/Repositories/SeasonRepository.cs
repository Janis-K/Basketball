using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class SeasonRepository : RepositoryBase<Season>, ISeasonRepository
    {
        public SeasonRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }

    public interface ISeasonRepository : IRepository<Season> { }
}
