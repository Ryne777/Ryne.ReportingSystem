namespace Ryne.ReportingSystem.Application.Models
{
    /// <summary>
    /// Тип дефектоскопа
    /// </summary>
    public record TypeOfDefectoscopeDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название типа дефектоскопа
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
