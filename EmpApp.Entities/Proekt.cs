using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
   public class Proekt
    {
        public Guid Id { get; set; }

        public Guid Employees { get; set; }

        public int TimeStart { get; set; }

        public int TimeFinish { get; set; }



    }
}
