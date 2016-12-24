using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindLog.Models
{
    public class Spot
    {        
        public int Id { get; set; }
        public string  Name { get; set; }
        public string City { get; set; }
        public string Province { get; set; }
        public string Country { get; set; }
        public double Lat { get; set; }
        public double Long { get; set; }
        public DateTime Created { get; set; }        
        public string Memo { get; set; }
    }
}
