using System;
using System.ComponentModel.DataAnnotations;

namespace WindLog.ViewModels
{
    public class SpotViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 5)]
        public string Name { get; set; }
        
        [StringLength(20)]
        public string City { get; set; }
        
        [StringLength(20)]
        public string Province { get; set; }
        
        [StringLength(20)]
        public string Country { get; set; }

        public double Lat { get; set; }

        public double Long { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public bool Active { get; set; }

        public string Memo { get; set; }
    }
}
