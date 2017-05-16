using System.Collections.Generic;
using System.Linq;
using Basketball.Data.Infrastructure;
using Basketball.Models.Models;

namespace Basketball.Data.Repositories
{
    public class TeamRepository : RepositoryBase<Team>, ITeamRepository
    {
        public TeamRepository(IDbFactory dbFactory) : base(dbFactory) { }

        public Team GetTeamByName(string teamName)
        {
            var team = this.DbContext.Teams.FirstOrDefault(c => c.TeamName == teamName);

            return team;
        }

        //public IEnumerable<Team> GetTeamsByCountry(string countryId)
        //{
        //    var teams = 
        //}

    }

    public interface ITeamRepository : IRepository<Team> { }
}
