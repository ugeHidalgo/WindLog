using System;
using System.Collections.Generic;

namespace WindLog.Models
{
    public class Material
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }        
        public DateTime Purchase { get; set; }
        public DateTime Created { get; set; }
        public string Memo { get; set; }

        #region relations
        public MaterialType MaterialType { get; set; }        
        //public ICollection<Session> Sessions { get; set; } Not needed
        #endregion
    }
}
