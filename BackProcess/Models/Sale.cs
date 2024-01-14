using System;
using System.Collections.Generic;

namespace BackProcess.Models
{
    public partial class Sale
    {
        public int Id { get; set; }
        public int? WorkerId { get; set; }
        public int? Price { get; set; }
    }
}
