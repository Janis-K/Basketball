using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Basketball.Data.Infrastructure;
using Basketball.Data.Repositories;
using Basketball.Models.Models;

namespace Basketball.Service
{
    public interface ITeamService
    {
        IEnumerable<Team> GetTeams();
        Team GetTeamById(int id);
        IEnumerable<Team> GetTeamsByCountry(string name);
        void CreateTeam(Team team);
        void SaveTeam();
    }

    public class TeamService : ITeamService
    {
        private readonly ITeamRepository teamRepository;
        private readonly IUnitOfWork unitOfWork;

        public TeamService(ITeamRepository teamRepository, IUnitOfWork unitOfWork)
        {
            this.teamRepository = teamRepository;
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Team> GetTeams()
        {
            return teamRepository.GetAll();
        }

        public Team GetTeamById(int id)
        {
            return teamRepository.GetById(id);
        }

        public IEnumerable<Team> GetTeamsByCountry(string name)
        {
            return teamRepository.GetAll().Where(c => c.TeamCountry.CountryName == name);
        }

        public void CreateTeam(Team team)
        {
            teamRepository.Add(team);
        }

        public void SaveTeam()
        {
            unitOfWork.Commit();
        }
    }
}
