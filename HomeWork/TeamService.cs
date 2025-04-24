using HomeWork.DAL.Entities;
using HomeWork.DAL;
using System.Collections.Generic;

namespace HomeWork
{
    public class TeamService
    {
        private readonly TeamRepository _teamRepo;

        public TeamService()
        {
            _teamRepo = new TeamRepository();
        }

        public IEnumerable<Team> GetAllTeams()
        {
            return _teamRepo.GetAll();
        }

        public void AddTeam(Team team)
        {
            _teamRepo.Add(team);
        }

        public void UpdateTeam(Team team)
        {
            _teamRepo.Update(team);
        }

        public void DeleteTeam(Team team)
        {
            _teamRepo.Delete(team);
        }

        public Team GetTeamByCriteria(string criterion)
        {
            return _teamRepo.GetTeamByCriteria(criterion);
        }
    }
}
