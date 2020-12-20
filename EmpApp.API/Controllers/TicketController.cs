using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CyberAge.Domain.Services.Tasks;
using CyberAge.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CyberAge.API.Controllers
{
    /// <summary>
    /// Контроллер компаний
    /// </summary>
    //[Authorize("Bearer")]
    [Route("/Ticket")]
    [AllowAnonymous]
    public class TicketController : Controller
    {
        private readonly TicketService _ticketService;

        public TicketController(TicketService ticketService)
        {
            _ticketService = ticketService;
        }


        /// <summary>
        /// Получение компании
        /// </summary>
        [HttpGet]
        [Route("/{номер билета}")]
        public async Task<Ticket> GetTicket([FromQuery] Guid id)
        {
            return _ticketService.GetTicket(id);
        }

        /// <summary>
        /// Получение компаний
        /// </summary>
        [HttpGet]
        public async Task<List<Ticket>> GetTicket()
        {
            return _ticketService.GetTickets();
        }

        /// <summary>
        /// Добавлени компании
        /// </summary>
        [HttpPost]
        public async Task AddTicket([FromBody] Ticket ticket)
        {
            _ticketService.AddTicket(ticket);
        }

        /// <summary>
        /// Изменение компании
        /// </summary>
        [HttpPatch]
        public async Task EditTicket([FromBody] Ticket ticket)
        {
            _ticketService.EditTicket(ticket);
        }

        /// <summary>
        /// Удаление компании
        /// </summary>
        [HttpDelete]
        public async Task RemoveTicket([FromQuery] Guid id)
        {
            _ticketService.RemoveTicket(id);
        }
    }
}