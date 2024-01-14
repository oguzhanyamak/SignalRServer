using System;
using System.Collections.Generic;

namespace BackProcess.Models
{
    public partial class Worker
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
    }
}
