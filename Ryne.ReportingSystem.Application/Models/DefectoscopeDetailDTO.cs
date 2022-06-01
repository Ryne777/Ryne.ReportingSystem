namespace Ryne.ReportingSystem.Application.Models
{
    public record DefectoscopeDetailDTO: DefectoscopeDTO
    {
        
        /// <summary>
        /// Id типа дефектоскопа
        /// </summary>
        public Guid TypeOfDefectoscopeId { get; set; }        
        /// <summary>
        /// Id организации владеющая
        /// </summary>
        public Guid OrganizationId { get; set; }        
        /// <summary>
        /// Список ремонтов
        /// </summary>
        public virtual List<RepairDTO>? Repairs { get; set; }
    }
}
