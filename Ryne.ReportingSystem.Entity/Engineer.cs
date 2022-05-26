using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Инженер электроник
    /// </summary>
    public class Engineer : Identity
    {
        public string? Name { get; set; }
        public virtual List<Repair> Repairs { get; set; } = new List<Repair>();
    }
}
