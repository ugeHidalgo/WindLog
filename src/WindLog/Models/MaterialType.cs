﻿using System;
using System.Collections.Generic;

namespace WindLog.Models
{
    public class MaterialType
    {        
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public DateTime Created { get; set; }
        public bool Active { get; set; } = true;
        public string Memo { get; set; }
    }
}
