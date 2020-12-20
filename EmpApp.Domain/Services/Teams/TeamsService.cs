using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.Employees
{
    public class TeamService
    {
        private readonly DatabaseContext _dbContext;
        public TeamService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Team GetTeam(Guid id)
        {
            return _dbContext.Teams.First(e => e.Id == id);
        }

        public List<Team> GetTeam()
        {
            return _dbContext.Teams.ToList();
        }

        public void AddTeam(Team team)
        {
            var editableTeams = team;
            editableTeams.Id = Guid.NewGuid();
            _dbContext.Add(editableTeams);
            _dbContext.SaveChanges();
        }

        public void RemoveTeam(Guid id)
        {
            var teams = GetTeam(id);
            _dbContext.Remove(teams);
            _dbContext.SaveChanges();
        }

        public void EditTeam(Team team)
        {
            var editableTeams = team;
            editableTeams.Id = team.Id;
            editableTeams.Director = team.Director;
            editableTeams.Employees = team.Employees;
            editableTeams.Tasks = team.Tasks;
            _dbContext.SaveChanges();
        }
    }
}