namespace Ryne.ReportingSystem.Application.Models
{
    public record RepairDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Дата калибровки
        /// </summary>
        public DateTime DateOfCalibration { get; set; }
    }
}