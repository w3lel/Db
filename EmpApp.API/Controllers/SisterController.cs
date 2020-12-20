using CyberAge.Domain.Services.Employees;
using CyberAge.Domain.Services.SisterCompany;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Threading.Tasks;

namespace CyberAge.API.Controllers
{

    /// <summary>
    /// Контроллер компаний
    /// </summary>
    //[Authorize("Bearer")]
    [Route("Sister company")]
    [AllowAnonymous]
    public class SisterController : Controller
    {
        private readonly SisterService _sisterService;

        public SisterController(SisterService sisterService)
        {
           _sisterService = sisterService;
        }


        /// <summary>
        /// Получение компании
        /// 
        /// </summary>
        [HttpGet]
        [Route("Id дочерней компании")]
        public async Task<SisterСompany> GetSister([FromQuery] Guid id)
        {
            return _sisterService.GetSister(id);
        }

        /// <summary>
        /// Получение компаний
        /// </summary>
        [HttpGet]
        public async Task<List<SisterСompany>> GetSister()
        {
            return _sisterService.GetSister();
        }

        /// <summary>
        /// Добавлени компании
        /// </summary>
        [HttpPost]
        public async Task AddSister([FromBody] SisterСompany sisterСompany)
        {
           _sisterService.AddSister(sisterСompany);

        }

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
        public async Task EditSister([FromBody] SisterСompany sisterСompany)
        {
            _sisterService.EditCompany(sisterСompany);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        [HttpDelete]
        public async Task RemoveSister([FromQuery] Guid id)
        {
           _sisterService.RemoveSister(id);
        }
    }
}