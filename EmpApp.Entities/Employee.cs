using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
    public class Event
    {
        public Guid Id { get; set; }
        
        public string FullName { get; set; }
        
        public DateTime DeviceDate { get; set; }

        public int HoursNumber { get; set; }

        public List<Guid> Tasks { get; set; }

        public Guid Role { get; set; }
    }
}