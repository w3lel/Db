using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
    public class SisterСompany
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public Guid Director { get; set; }

        public List<Guid> Teams { get; set; }
    }
}