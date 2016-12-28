using System.Collections.Generic;

namespace WindLog.Models
{
    public interface IWindlogRepository
    {
        IEnumerable<MaterialType> GetAllMaterialTypes();
        IEnumerable<Material> GetAllMaterials();
        IEnumerable<Spot> GetAllSpots();
        IEnumerable<Session> GetAllSessions();
    }
}
