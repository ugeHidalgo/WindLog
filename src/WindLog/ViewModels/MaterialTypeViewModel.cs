using System;
using System.ComponentModel.DataAnnotations;

namespace WindLog.ViewModels
{
    public class MaterialTypeViewModel
    {
        [Required]
        [StringLength(20, MinimumLength = 5)]        
        public string UserName { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string Memo { get; set; }
    }
}
