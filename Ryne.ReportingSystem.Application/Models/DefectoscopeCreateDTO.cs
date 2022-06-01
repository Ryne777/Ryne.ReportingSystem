namespace Ryne.ReportingSystem.Application.Models
{
    public class DefectoscopeCreateDTO
    {
        /// <summary>
        /// Серийный номер
        /// </summary>
        public string SerialNumber { get; set; } = null!;
        /// <summary>
        /// Год изготовления
        /// </summary>
        public uint ProductionYear { get; set; }
        /// <summary>
        /// Id типа дефектоскопа
        /// </summary>
        public Guid TypeOfDefectoscopeId { get; set; }        
        /// <summary>
        /// Id организации владеющая
        /// </summary>
        public Guid OrganizationId { get; set; }        
       
        
    }
}
