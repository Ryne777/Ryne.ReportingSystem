namespace Ryne.ReportingSystem.Application.Models
{
    public record TypeOfDefectoscopeDetailDTO: TypeOfDefectoscopeDTO
    {
        /// <summary>
        /// Список дефектоскопов конкретного типа
        /// </summary>
        public virtual List<DefectoscopeDTO>? Defectoscopes { get; set; }
    }
}
