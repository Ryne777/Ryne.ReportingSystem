using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization: Identity
    {
        public string? Name { get; set; }
        public virtual List<Defectoscope> Defectoscopes { get; set; } = new List<Defectoscope>();
        

    }
}