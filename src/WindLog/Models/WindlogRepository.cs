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

        public IEnumerable<Material> GetAllMaterials()
        {
            return _context.Materials.Include(x => x.MaterialType);
        }

        public IEnumerable<MaterialType> GetAllMaterialTypes()
        {
            return _context.MaterialTypes;
        }

        public IEnumerable<Session> GetAllSessions()
        {
            var data = _context.Sessions.Include(x => x.Spot);
            foreach (var session in data)
            {
                session.SessionMaterials = _context.SessionMaterials
                    .Where(x => x.SessionId == session.Id)
                    .Include(x => x.Material)
                    .Include(x => x.Material.MaterialType)
                    .ToList();
            }            
            return data;
        }

        public IEnumerable<Spot> GetAllSpots()
        {
            return _context.Spots;
        }
    }
}
