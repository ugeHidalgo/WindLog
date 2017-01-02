namespace WindLog.Models
{
    public class SessionMaterials
    {
        public string UserName { get; set; }
        public int SessionId { get; set; }
        public Session Session { get; set; }
        public int MaterialId { get; set; }
        public Material Material { get; set; }
    }
}
