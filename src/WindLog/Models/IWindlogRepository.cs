using System.Collections.Generic;
using System.Threading.Tasks;

namespace WindLog.Models
{
    public interface IWindlogRepository
    {        
        IEnumerable<Material> GetAllMaterials(string userName);
        Material GetMaterialById(int id, string userName);
        void AddMaterial(Material material);
        void UpdateMaterial(Material material);

        IEnumerable<MaterialType> GetAllMaterialTypes(string userName);
        MaterialType GetMaterialTypeById(int id, string userName);
        void AddMaterialType(MaterialType matType);
        void UpdateMaterialType(MaterialType matType);
        bool RemoveMaterialType(int id, string username);

        IEnumerable<Spot> GetAllSpots(string userName);
        IEnumerable<Session> GetAllSessions(string userName);

        Task<bool> SaveChangesAsync();                
    }
}
