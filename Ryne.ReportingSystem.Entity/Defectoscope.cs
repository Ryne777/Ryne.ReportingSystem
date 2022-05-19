using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Дефектоскоп
    /// </summary>
    public class Defectoscope: Identity
    {   
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string? SerialNumber { get; set; }
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
        /// Id типа дефектоскопа
        /// </summary>
        public Guid TypeOfDefectoscopelId { get; set; }
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
        /// ID электроника
        /// </summary>
        public Guid EngineerID { get; set; }
        /// <summary>
        /// Электроник производивший ремонт
        /// </summary>
        public Engineer? Engineer { get; set; }

    }
}
