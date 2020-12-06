using System;

namespace CyberAge.Entities
{
    public class Ticket
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int PresentableId { get; set; }
    }
}