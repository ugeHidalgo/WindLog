using Microsoft.EntityFrameworkCore;

namespace WindLog.Models
{
    public class WindlogContext : DbContext
    {        
        public DbSet<Spot> Spots { get; set; }        
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public WindlogContext()
        {

        }        
    }
}
