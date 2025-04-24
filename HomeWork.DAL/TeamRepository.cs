using HomeWork.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeWork.DAL
{
    public class TeamRepository
    {
        private readonly AppDbContext _context;

        public TeamRepository()
        {
            _context = new AppDbContext();
        }

        public IEnumerable<Team> GetAll()
        {
            return _context.Teams.ToList();
        }

        public Team FindByName(string name)
        {
            foreach (var team in _context.Teams)
            {
                if (team.Name == name)
                {
                    return team;
                }
            }
            return null;
        }

        public void Add(Team team)
        {
            _context.Teams.Add(team);
            _context.SaveChanges();
        }

        public void Update(Team team)
        {
            _context.Teams.Update(team);
            _context.SaveChanges();
        }

        public void Delete(Team team)
        {
            _context.Teams.Remove(team);
            _context.SaveChanges();
        }

        public Team GetTeamByCriteria(string criterion)
        {
            Team result = null;
            int maxValue = -1;

            foreach (var team in _context.Teams)
            {
                int currentValue = 0;

                switch (criterion.ToLower())
                {
                    case "wins":
                        currentValue = team.Wins;
                        break;
                    case "losses":
                        currentValue = team.Losses;
                        break;
                    case "draws":
                        currentValue = team.Draws;
                        break;
                    case "goals scored":
                        currentValue = team.GoalsScored;
                        break;
                    case "goals conceded":
                        currentValue = team.GoalsConceded;
                        break;
                    default:
                        return null;
                }

                if (currentValue > maxValue)
                {
                    maxValue = currentValue;
                    result = team;
                }
            }

            return result;
        }
    }
}
