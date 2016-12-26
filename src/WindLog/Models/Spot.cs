using System;
using System.Collections.Generic;

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

        #region Relations
        public ICollection<Session> Sessions { get; set; }
        #endregion
    }
}
