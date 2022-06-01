namespace Ryne.ReportingSystem.Application.Models
{
    public record EngineerCreateDTO
    {
        /// <summary>
        /// Имя электорника
        /// </summary>
        public string Name { get; set; } = null!;
    }
}
