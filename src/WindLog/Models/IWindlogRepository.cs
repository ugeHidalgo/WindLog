﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindLog.Models
{
    public interface IWindlogRepository
    {
        IEnumerable<MaterialType> GetAllMaterialTypes(string userName);
        IEnumerable<Material> GetAllMaterials(string userName);
        IEnumerable<Spot> GetAllSpots(string userName);
        IEnumerable<Session> GetAllSessions(string userName);

        void AddMaterialType(MaterialType matType);
        void UpdateMaterialType(MaterialType matType);
        bool RemoveMaterialType(int id, string username);

        void AddMaterial(Material material);
        void UpdateMaterial(Material material);

        Task<bool> SaveChangesAsync();
        Material GetMaterialById(int id, string userName);
    }
}
