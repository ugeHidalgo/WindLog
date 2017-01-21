using System;
using System.ComponentModel.DataAnnotations;

namespace WindLog.ViewModels
{
    public class MaterialTypeViewModel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        public string Name { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Memo { get; set; }
    }
}
