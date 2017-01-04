using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using WindLog.Models;

namespace WindLog.ViewModels
{
    public class SessionViewModel
    {
        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }

        public DateTime SessionDate { get; set; } = DateTime.UtcNow;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string Memo { get; set; }

        public Spot Spot { get; set; }

        public ICollection<MaterialViewModel> Materials { get; set; }
    }
}
