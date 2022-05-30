namespace Ryne.ReportingSystem.Web.Models
{
    public record DefectoscopeDetailDTO
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; } = null!;
        public uint ProductionYear { get; set; }
        /// <summary>
        /// Id типа дефектоскопа
        /// </summary>
        public Guid TypeOfDefectoscopeId { get; set; }
        public string TypeOfDefectoscopeName { get; set; } = null!;
        /// <summary>
        /// Id организации владеющая
        /// </summary>
        public Guid OrganizationId { get; set; }
        /// <summary>
        /// Организация владеющая дефектоскопом
        /// </summary>
        public string OrganizationName { get; set; } = null!;
        /// <summary>
        /// Список ремонтов
        /// </summary>
        public virtual List<RepairDTO>? Repairs { get; set; }
    }
}
