namespace Ryne.ReportingSystem.Application.Models
{
    public record OrganizationDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Название организации
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
