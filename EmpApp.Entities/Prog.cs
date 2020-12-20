using System;
using System.Collections.Generic;

namespace CyberAge.Entities
{
   public class Programma
    {
        public Guid Id { get; set; }

        public Guid Employee { get; set; }

        public int TimeStart { get; set; }

        public int TimeFinish { get; set; }



    }
}
