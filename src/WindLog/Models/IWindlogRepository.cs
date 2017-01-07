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

        Task<bool> SaveChangesAsync();
    }
}
