using System;

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
