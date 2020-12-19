using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.Tasks
{
    public class TicketService
    {
        private readonly DatabaseContext _dbContext;
        public TicketService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Ticket GetTasks(Guid id)
        {
            return _dbContext.Tickets.First(e => e.Id == id);
        }

        public List<Ticket> GetTasks()
        {
            return _dbContext.Tickets.ToList();
        }

        public void AddTicket(Ticket tickets)
        {
            var editableTicket = tickets;
            editableTicket.Id = Guid.NewGuid();
            _dbContext.Add(editableTicket);
            _dbContext.SaveChanges();
        }

        public void RemoveTicket(Guid id)
        {
            var tasks = GetTasks(id);
            _dbContext.Remove(tasks);
            _dbContext.SaveChanges();
        }

        public void EditTasks(Ticket ticket)
        {
            var editableTicket = ticket;
            editableTicket.Id = ticket.Id;
            editableTicket.Name = ticket.Name;
            editableTicket.Description= ticket.Description;
            editableTicket.PresentableId = ticket.PresentableId;
            _dbContext.SaveChanges();
        }
    }
}