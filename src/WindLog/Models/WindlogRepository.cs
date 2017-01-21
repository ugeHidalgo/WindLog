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

        #region Material Types
        public IEnumerable<MaterialType> GetAllMaterialTypes(string userName)
        {
            return _context.MaterialTypes
                .Where(x => x.UserName == userName);
        }

        public void AddMaterialType(MaterialType matType)
        {
            matType.Created = DateTime.Now;
            _context.Add(matType);
        }

        public void UpdateMaterialType(MaterialType matType)
        {
            _context.Update(matType);
        }

        public bool RemoveMaterialType(int id, string username)
        {
            var materialTypeToRemove = _context.MaterialTypes.FirstOrDefault(x => x.Id == id && x.UserName == username);
            if (materialTypeToRemove == null) return false;
            _context.MaterialTypes.Remove(materialTypeToRemove);
            return true;
        }

        #endregion

        #region Materials

        public IEnumerable<Material> GetAllMaterials(string userName)
        {
            return _context.Materials
                .Include(x => x.MaterialType)
                .Where(x => x.UserName == userName);
        }

        public Material GetMaterialById(int id, string userName)
        {
            return _context.Materials
                .Include(x => x.MaterialType)
                .FirstOrDefault(x => x.UserName == userName && x.Id == id);
        }

        public void AddMaterial(Material material)
        {
            var materialType = _context.MaterialTypes.FirstOrDefault(x => x.Id == material.MaterialType.Id);
            material.Created = DateTime.Now;
            material.MaterialType = materialType;

            _context.Add(material);
        }

        public void UpdateMaterial(Material material)
        {
            _context.Update(material);
        }

        #endregion        

        #region Sessions

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

        #endregion

        #region Spots

        public IEnumerable<Spot> GetAllSpots(string userName)
        {
            return _context.Spots
                .Where(x => x.UserName == userName);
        }

        #endregion

        #region Common

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        #endregion
    }
}
