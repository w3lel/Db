using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.Companies
{
    public class CompanyService
    {
        private readonly DatabaseContext _dbContext;
        public CompanyService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Company GetCompany(Guid id)
        {
            return _dbContext.Companies.First(e => e.Id == id);
        }
        
        public List<Company> GetCompanies()
        {
            return _dbContext.Companies.ToList();
        }
        
        public void AddCompany(Company company)
        {
            var editableCompany = company;
            editableCompany.Id = Guid.NewGuid();
            _dbContext.Add(editableCompany);
            _dbContext.SaveChanges();
        }
        
        public void RemoveCompany(Guid id)
        {
            var company = GetCompany(id);
            _dbContext.Remove(company);
            _dbContext.SaveChanges();
        }
        
        public void EditCompany(Company company)
        {
            var editableCompany = company;
            editableCompany.Name = company.Name;
            editableCompany.Director = company.Director;
            editableCompany.SisterCompanies = company.SisterCompanies;
            _dbContext.SaveChanges();
        }
    }
}