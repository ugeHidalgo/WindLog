using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            return _context.Materials.ToList();
        }

        public IEnumerable<MaterialType> GetAllMaterialTypes()
        {
            return _context.MaterialTypes.ToList();
        }

        public IEnumerable<Session> GetAllSessions()
        {
            return _context.Sessions.ToList();
        }

        public IEnumerable<Spot> GetAllSpots()
        {
            return _context.Spots.ToList();
        }
    }
}
