using System;
using System.Collections.Generic;

namespace WindLog.Models
{
    public class Session
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime SessionDate { get; set; }        
        public DateTime Created { get; set; }
        public string Memo { get; set; }

        #region relations
        public Spot Spot { get; set; }
        public ICollection<SessionMaterials> SessionMaterials { get; set; }

        #endregion
    }
}
