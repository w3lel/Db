using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.proekt
{
    public class ProektService
    {
        private readonly DatabaseContext _dbContext;
        public ProektService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Proekt GetProekt(Guid id)
        {
            return _dbContext.Proekts.First(e => e.Id == id);
        }

        public List<Proekt> GetProekt()
        {
            return _dbContext.Proekts.ToList();
        }

        public void AddProekt(Proekt proekt)
        {
            var editableProekt =proekt;
            editableProekt.Id = Guid.NewGuid();
            _dbContext.Add(editableProekt);
            _dbContext.SaveChanges();
        }

        public void RemoveProekt(Guid id)
        {
            var proekt = GetProekt(id);
            _dbContext.Remove(proekt);
            _dbContext.SaveChanges();
        }

        public void EditProekt(Proekt proekt)
        {
            var editableProekt = proekt;
            editableProekt.Id = proekt.Id;
            editableProekt.Employees = proekt.Employees;
            editableProekt.TimeStart = proekt.TimeStart;
            editableProekt.TimeFinish = proekt.TimeFinish;
                     _dbContext.SaveChanges();
        }
    }
}
