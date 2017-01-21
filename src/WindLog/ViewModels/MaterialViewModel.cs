using System;
using System.ComponentModel.DataAnnotations;
using WindLog.Models;

namespace WindLog.ViewModels
{
    public class MaterialViewModel
    {
        public int Id { get; set; }

        public string UserName { get; set; }

        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        [StringLength(20)]
        public string Brand { get; set; }

        [Required]
        [StringLength(20)]
        public string Model { get; set; }

        public int Year { get; set; }

        public DateTime DatePurchased { get; set; } = DateTime.UtcNow;

        public DateTime DateCreated { get; set; } = DateTime.UtcNow;

        public string Memo { get; set; }

        public bool SecondHand { get; set; }

        public bool State { get; set; }

        public MaterialTypeViewModel MaterialTypeViewModel { get; set; }
    }
}
