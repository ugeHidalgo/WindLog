using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Framework.Configuration;

namespace WindLog.Models
{
    public class WindlogContext : IdentityDbContext<WindlogUser>
    {
        private IConfigurationRoot _config;

        public DbSet<Spot> Spots { get; set; }        
        public DbSet<MaterialType> MaterialTypes { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<Session> Sessions { get; set; }
        public DbSet<SessionMaterials> SessionMaterials { get; set; }


        public WindlogContext(IConfigurationRoot config, DbContextOptions options):base(options)
        {
            _config = config;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SessionMaterials>().HasKey(x => new { x.SessionId, x.MaterialId });

            modelBuilder.Entity<SessionMaterials>()
                .HasOne(x=>x.Material)
                .WithMany(p => p.SessionMaterials)
                .HasForeignKey(x=>x.MaterialId);

            modelBuilder.Entity<SessionMaterials>()
                .HasOne(x => x.Session)
                .WithMany(p => p.SessionMaterials)
                .HasForeignKey(x => x.SessionId);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            optionsBuilder.UseSqlServer(_config["ConnectionStrings:WindlogContextConnection"]);
        }
    }
}
