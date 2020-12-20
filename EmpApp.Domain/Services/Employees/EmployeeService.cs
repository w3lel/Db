using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.Employees
{
    public class EmployeeService
    {
        private readonly DatabaseContext _dbContext;
        public EmployeeService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Event GetEmployee(Guid id)
        {
            return _dbContext.Employees.First(e => e.Id == id);
        }

        public List<Event> GetEmployee()
        {
            return _dbContext.Employees.ToList();
        }

        public void AddEmployee(Event employee)
        {
            var editableEmployee = employee;
            editableEmployee.Id = Guid.NewGuid();
            _dbContext.Add(editableEmployee);
            _dbContext.SaveChanges();
        }

        public void RemoveEmployee(Guid id)
        {
            var employee = GetEmployee(id);
            _dbContext.Remove(employee);
            _dbContext.SaveChanges();
        }

        public void EditEmployee(Event employee)
        {
            var editableEmployee = employee;
            editableEmployee.Id = employee.Id;
            editableEmployee.FullName = employee.FullName;
            editableEmployee.DeviceDate = employee.DeviceDate;
            editableEmployee.HoursNumber = employee.HoursNumber;
            editableEmployee.Tasks = employee.Tasks;
            editableEmployee.Role = employee.Role;
            _dbContext.SaveChanges();
        }
    }
}