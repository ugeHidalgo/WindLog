using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System;
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

        public void AddMaterialType(MaterialType matType)
        {
            matType.Created = DateTime.Now;
            _context.Add(matType);
        }

        public bool RemoveMaterialType(int id, string username)
        {            
            var materialTypeToRemove = _context.MaterialTypes.FirstOrDefault(x => x.Id == id && x.UserName == username);
            if (materialTypeToRemove == null) return false;
            _context.MaterialTypes.Remove(materialTypeToRemove);
            return true;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}
