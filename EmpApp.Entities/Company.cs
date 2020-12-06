using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
    public class Company
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public List<Guid> SisterCompanies { get; set; }
        
        public Guid Director { get; set; }

    }
}