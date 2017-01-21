using System;
using System.Collections.Generic;

namespace WindLog.Models
{
    public class Material
    {        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Year { get; set; }        
        public DateTime Purchase { get; set; }
        public DateTime Created { get; set; }
        public string Memo { get; set; }
        public bool SecondHand { get; set; }
        public bool State { get; set; } = true;

        #region relations
        public MaterialType MaterialType { get; set; }
        public ICollection<SessionMaterials> SessionMaterials { get; set; }

        #endregion
    }
}
