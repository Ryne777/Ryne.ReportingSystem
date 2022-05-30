namespace Ryne.ReportingSystem.Web.Models
{
    public record RepairDetailDTO: RepairDTO
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
        /// Дата последнего ремонта
        /// </summary>
        public DateTime DateOfLastRepair { get; set; }
        /// <summary>
        /// Тип ремонта
        /// </summary>
        public string TypeOfRepairTostring { get; set; } = null!;
        /// <summary>
        /// Id дефектоскопа
        /// </summary>
        public Guid DefectoscopeId { get; set; }
        /// <summary>
        /// Дефектоскоп на ремонте
        /// </summary>
        public string DefectoscopeSerialNumber { get; set; } = null!;
        /// <summary>
        /// ID электроника
        /// </summary>
        public Guid EngineerID { get; set; }
        /// <summary>
        /// Электроник производивший ремонт
        /// </summary>
        public string EngineerName { get; set; } = null!;

    }
}
