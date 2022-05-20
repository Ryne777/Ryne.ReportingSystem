using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Дефектоскоп
    /// </summary>
    public class Defectoscope : Identity
    {
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string? SerialNumber { get; set; }
        /// <summary>
        /// Id типа дефектоскопа
        /// </summary>
        public Guid TypeOfDefectoscopeId { get; set; }
        /// <summary>
        ///  Тип дефектоскопа
        /// </summary>
        public virtual TypeOfDefectoscope? TypeOfDefectoscope { get; set; }
        /// <summary>
        /// Id организации владеющая
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary>
        /// Организация владеющая дефектоскопом
        /// </summary>
        public virtual Organization? Organization { get; set; }
        /// <summary>
        /// Список ремонтов
        /// </summary>
        public List<Repair> Repairs { get; set; } = new List<Repair>();

    }
}
