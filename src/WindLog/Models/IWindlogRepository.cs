using System.Collections.Generic;

namespace WindLog.Models
{
    public interface IWindlogRepository
    {
        IEnumerable<MaterialType> GetAllMaterialTypes(string userName);
        IEnumerable<Material> GetAllMaterials(string userName);
        IEnumerable<Spot> GetAllSpots(string userName);
        IEnumerable<Session> GetAllSessions(string userName);
    }
}
