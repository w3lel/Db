using System;
using System.Collections.Generic;
using System.Linq;
using CyberAge.Database;
using CyberAge.Entities;

namespace CyberAge.Domain.Services.prog
{
    public class ProgrammaService
    {
        private readonly DatabaseContext _dbContext;
        public ProgrammaService(DatabaseContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Programma GetProgramma(Guid id)
        {
            return _dbContext.Programmas.First(e => e.Id == id);
        }

        public List<Programma> GetProgrammas()
        {
            return _dbContext.Programmas.ToList();
        }

        public void AddProgramma(Programma programma)
        {
            var editableProgramma =programma;
            editableProgramma.Id = Guid.NewGuid();
            _dbContext.Add(editableProgramma);
            _dbContext.SaveChanges();
        }

        public void RemoveProgramma(Guid id)
        {
            var programma = GetProgramma(id);
            _dbContext.Remove(programma);
            _dbContext.SaveChanges();
        }

        public void EditProgramma(Programma programma)
        {
            var editableProgramma = programma;
            editableProgramma.Id = programma.Id;
            editableProgramma.TimeStart = programma.TimeStart;
            editableProgramma.TimeFinish = programma.TimeFinish;
          //editableEmployee.HoursNumber = employee.HoursNumber;
           //editableEmployee.Tasks = employee.Tasks;
           //editableEmployee.Role = employee.Role;
            _dbContext.SaveChanges();
        }
    }
}
