using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Организация
    /// </summary>
    public class Organization: Identity
    {
        public string Name { get; set; }
        public Organization(string name) => Name = name;

    }
}