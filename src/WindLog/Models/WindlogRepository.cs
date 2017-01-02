using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace WindLog.Models
{
    public class WindlogRepository : IWindlogRepository
    {
        private WindlogContext _context;

        public WindlogRepository(WindlogContext context)
        {
            _context = context;
        }

        public IEnumerable<Material> GetAllMaterials(string userName)
        {
            return _context.Materials
                .Include(x => x.MaterialType)
                .Where(x => x.UserName == userName);
        }

        public IEnumerable<MaterialType> GetAllMaterialTypes(string userName)
        {
            return _context.MaterialTypes
                .Where(x=>x.UserName == userName);
        }

        public IEnumerable<Session> GetAllSessions(string userName)
        {
            var data = _context.Sessions
                .Include(x => x.Spot)
                .Where(x => x.UserName == userName);
            foreach (var session in data)
            {
                session.SessionMaterials = _context.SessionMaterials
                    .Where(x => x.SessionId == session.Id && x.UserName == userName)
                    .Include(x => x.Material)
                    .Include(x => x.Material.MaterialType)
                    .ToList();
            }            
            return data;
        }

        public IEnumerable<Spot> GetAllSpots(string userName)
        {
            return _context.Spots
                .Where(x => x.UserName == userName);
        }
    }
}
