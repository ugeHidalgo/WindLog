using Microsoft.EntityFrameworkCore;
using Microsoft.Framework.Configuration;

namespace WindLog.Models
{
    public class WindlogContext : DbContext
    {
        private IConfigurationRoot _config;

        public DbSet<Spot> Spots { get; set; }        
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Session> Sessions { get; set; }


        public WindlogContext(IConfigurationRoot config, DbContextOptions options):base(options)
        {
            _config = config;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WindlogContextConnection"]);
        }
    }
}
