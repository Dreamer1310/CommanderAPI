using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Commander.Dtos
{
    public class CommandUpdateDto
    {
        [Required]
        [MaxLength(250)]
        public String HowTo { get; set; }
        [Required]
        public String Line { get; set; }
        [Required]
        public String Platform { get; set; }
    }
}
