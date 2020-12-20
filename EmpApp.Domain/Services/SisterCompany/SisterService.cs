using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.SisterCompany
{
    public class SisterService
    {
        private readonly DatabaseContext _dbContext;
        public SisterService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public SisterСompany GetSister(Guid id)
        {
            return _dbContext.SisterCompanies.First(e => e.Id == id);
        }

        public List<SisterСompany> GetSister()
        {
            return _dbContext.SisterCompanies.ToList();
        }

        public void AddSister(SisterСompany sisterСompany)
        {
            var editablesisterCompany = sisterСompany;
            editablesisterCompany.Id = Guid.NewGuid();
            _dbContext.Add(editablesisterCompany);
            _dbContext.SaveChanges();
        }

        public void RemoveSister(Guid id)
        {
            var sisterСompany = GetSister(id);
            _dbContext.Remove(sisterСompany);
            _dbContext.SaveChanges();
        }

        public void EditCompany(SisterСompany sisterСompany)
        {
            var editablesisterCompany = sisterСompany;
            editablesisterCompany.Id = editablesisterCompany.Id;
            editablesisterCompany.Name = editablesisterCompany.Name;
            editablesisterCompany.Director = editablesisterCompany.Director;
           editablesisterCompany.Teams = editablesisterCompany.Teams;
            _dbContext.SaveChanges();
        }
    }
}
