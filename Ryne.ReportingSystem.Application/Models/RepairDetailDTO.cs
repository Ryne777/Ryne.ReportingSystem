namespace Ryne.ReportingSystem.Application.Models
{
    public record RepairDetailDTO: RepairCreateDTO
    {
       
        public Guid Id { get; set; }        
        /// <summary>
        /// Дефектоскоп на ремонте
        /// </summary>
        public string DefectoscopeSerialNumber { get; set; } = null!;
        /// <summary>
        /// Тип ремонта
        /// </summary>
        public string TypeOfRepairTostring { get; set; } = null!;
        /// <summary>
        /// Электроник производивший ремонт
        /// </summary>
        public string EngineerName { get; set; } = null!;

    }
}
