using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CyberAge.Domain.Services.Employees;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberAge.API.Controllers
{
    /// <summary>
    /// Контроллер компаний
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Teams")]
    [AllowAnonymous]
    public class TeamController : Controller
    {
        private readonly TeamService _teamService;

        public TeamController(TeamService teamService)
        {
            _teamService = teamService;
        }


        /// <summary>
        /// </summary>
        [HttpGet]
        [Route("/")]
        public async Task<Team> GetTeam([FromQuery] Guid id)
        {
            return _teamService.GetTeam(id);
        }

        /// <summary>
        /// Получение компаний
        /// </summary>
        [HttpGet]
        public async Task<List<Team>> GetTeam()
        {
            return _teamService.GetTeam();
        }

        /// <summary>
        /// Добавлени компании
        /// </summary>
        [HttpPost]
        public async Task AddTeam([FromBody] Team team)
        {
            _teamService.AddTeam(team);
        }

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
        public async Task EditTeam([FromBody] Team team)
        {
            _teamService.EditTeam(team);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        [HttpDelete]
        public async Task RemoveTeam([FromQuery] Guid id)
        {
            _teamService.RemoveTeam(id);
        }
    }
}