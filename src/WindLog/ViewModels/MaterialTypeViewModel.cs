using System;
using System.ComponentModel.DataAnnotations;

namespace WindLog.ViewModels
{
    public class MaterialTypeViewModel
    {
        //[Required]
        //[StringLength(20, MinimumLength = 5)]        
        //public string UserName { get; set; }

        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public string Memo { get; set; }
    }
}
