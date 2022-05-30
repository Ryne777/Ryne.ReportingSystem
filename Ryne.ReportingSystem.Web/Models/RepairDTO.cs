namespace Ryne.ReportingSystem.Web.Models
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