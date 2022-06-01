namespace Ryne.ReportingSystem.Application.Models
{
    public record DefectoscopeDTO
    {
        public Guid Id { get; set; }
        public string SerialNumber { get; set; } = null!;
        /// <summary>
        /// Год изготовления
        /// </summary>
        public uint ProductionYear { get; set; }
        /// <summary>
        ///  Тип дефектоскопа
        /// </summary>
        public string TypeOfDefectoscopeName { get; set; } = null!;
        /// <summary>
        /// Организация владеющая дефектоскопом
        /// </summary>
        public string OrganizationName { get; set; } = null!;
    }
}
