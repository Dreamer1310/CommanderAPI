using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dtos
{
    public class CommandReadDto
    {
        public Int32 Id { get; set; }
        public String HowTo { get; set; }
        public String Line { get; set; }
    }
}
