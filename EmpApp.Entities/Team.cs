using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
    public class Team
    {
        public Guid Id { get; set; }

        public Guid Director { get; set; }

        public List<Guid> Employees { get; set; }

        public List<Guid> Tasks { get; set; }
    }
}