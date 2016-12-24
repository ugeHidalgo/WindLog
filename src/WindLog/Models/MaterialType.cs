using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WindLog.Models
{
    public class MaterialType
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Memo { get; set; }
    }
}
