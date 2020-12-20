using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CyberAge.Domain.Services.Companies;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberAge.API.Controllers
{
    /// <summary>
    /// Контроллер компаний
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Companies")]
    [AllowAnonymous]
    public class CompanyController : Controller
    {
        private readonly CompanyService _companyService;

        public CompanyController(CompanyService companyService)
        {
            _companyService = companyService;
        }


        /// <summary>
        /// Получение компании
        /// </summary>
        [HttpGet]
        [Route("/id")]
        public async Task<Company> GetCompany([FromQuery] Guid id)
        {
            return _companyService.GetCompany(id);
        }

        /// <summary>
        /// Получение компаний
        /// </summary>
        [HttpGet]
        public async Task<List<Company>> GetCompanies()
        {
            return _companyService.GetCompanies();
        }

        /// <summary>
        /// Добавлени компании
        /// </summary>
        [HttpPost]
        public async Task AddCompany([FromBody]Company company)
        {
            _companyService.AddCompany(company);
        }

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
        public async Task EditCompany([FromBody] Company company)
        {
            _companyService.EditCompany(company);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        [HttpDelete]
        public async Task RemoveCompany([FromQuery] Guid id)
        {
            _companyService.RemoveCompany(id);
        }
    }
}