using System;
using System.Collections.Generic;

namespace WindLog.Models
{
    public class MaterialType
    {        
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public string Memo { get; set; }

        #region relations
        //public ICollection<Material> Materials { get; set; }
        #endregion
    }
}
