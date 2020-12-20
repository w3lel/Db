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
    [Route("Employee")]
    [AllowAnonymous]
    public class EmployeeController : Controller
    {
        private readonly EmployeeService _employeeService;

        public EmployeeController(EmployeeService employeeService)
        {
            _employeeService = employeeService;
        }


        /// <summary>
        /// Получение компании
        /// </summary>
        [HttpGet]
        [Route("/{id}")]
        public async Task<Event> GetEmployee([FromQuery] Guid id)
        {
            return _employeeService.GetEmployee(id);
        }

        /// <summary>
        /// Получение компаний
        /// </summary>
        [HttpGet]
        public async Task<List<Event>> GetEmployee()
        {
            return _employeeService.GetEmployee();
        }

        /// <summary>
        /// Добавлени компании
        /// </summary>
        [HttpPost]
        public async Task AddEmployee([FromBody] Event employee)
        {
            _employeeService.AddEmployee(employee);

        }

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
        public async Task EditEmployee([FromBody] Event employee)
        {
           _employeeService.EditEmployee(employee);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        [HttpDelete]
        public async Task RemoveEmployee([FromQuery] Guid id)
        {
            _employeeService.RemoveEmployee(id);
        }
    }
}