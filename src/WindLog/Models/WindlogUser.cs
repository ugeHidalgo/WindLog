using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System;

namespace WindLog.Models
{
    public class WindlogUser : IdentityUser
    {
        public bool ActiveUser { get; set; }
        public DateTime Created { get; set; }
    }
}
