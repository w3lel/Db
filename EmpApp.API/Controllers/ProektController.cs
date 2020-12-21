using CyberAge.Domain.Services.Companies;
using CyberAge.Domain.Services.proekt;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CyberAge.API.Controllers
{
/// <summary>
/// Контроллер компаний
/// </summary>
//[Authorize("Bearer")]
[Route("Project")]
[AllowAnonymous]
public class ProektController : Controller
{
    private readonly ProektService _proektService;

    public ProektController(ProektService proektService)
    {
        _proektService = proektService;
    }


        /// <summary>
        /// Получение компании
        /// </summary>
        [HttpGet]
        [Route("Project id")]
        public async Task<Proekt> GetProekt([FromQuery] Guid id) => _proektService.GetProekt(id);
        [HttpGet]
        public async Task<List<Proekt>> GetProekt()
        {
            return _proektService.GetProekt();
        }


        [HttpPost]
        public async Task AddProekt([FromBody] Proekt proekt) => _proektService.AddProekt(proekt);

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
    public async Task EditProekt([FromBody]Proekt proekt)
    {
       _proektService.EditProekt(proekt);
    }

    /// <summary>
    /// Удаление компании
    /// </summary>
    [HttpDelete]
    public async Task RemoveProekt([FromQuery] Guid id)
    {
        _proektService.RemoveProekt(id);
    }
}
}