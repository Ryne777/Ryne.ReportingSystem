using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Ремонт
    /// </summary>
    public class Repair: Identity
    {        
        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime DateOfReceipt { get; set; }
        /// <summary>
        /// Дата выхода
        /// </summary>
        public DateTime DateOfRelease { get; set; }
        /// <summary>
        /// Дата калибровки
        /// </summary>
        public DateTime DateOfCalibration { get; set; }
        /// <summary>
        /// Дата последнего ремонта
        /// </summary>
        public DateTime DateOfLastRepair { get; set; }
        /// <summary>
        /// Тип ремонта
        /// </summary>
        public TypeOfRepair TypeOfRepair { get; set; }
        /// <summary>
        /// Id дефектоскопа
        /// </summary>
        public Guid DefectoscopeId { get; set; }
        /// <summary>
        /// Дефектоскоп на ремонте
        /// </summary>
        public virtual Defectoscope? Defectoscope { get; set; }
        /// <summary>
        /// ID электроника
        /// </summary>
        public Guid EngineerID { get; set; }
        /// <summary>
        /// Электроник производивший ремонт
        /// </summary>
        public virtual Engineer? Engineer { get; set; }
    }
}
