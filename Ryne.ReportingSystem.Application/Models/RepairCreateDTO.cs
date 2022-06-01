using Ryne.ReportingSystem.Entity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace Ryne.ReportingSystem.Application.Models
{
    /// <summary>
    /// Модель создания Ремонта
    /// </summary>
    public record RepairCreateDTO
    {
        /// <summary>
        /// Дата калибровки
        /// </summary>
        public DateTime DateOfCalibration { get; set; }
        /// <summary>
        /// Дата поступления
        /// </summary>
        public DateTime DateOfReceipt { get; set; }
        /// <summary>
        /// Дата выхода
        /// </summary>
        public DateTime DateOfRelease { get; set; }
        /// <summary>
        /// Дата последнего ремонта
        /// </summary>
        public DateTime DateOfLastRepair { get; set; }
        /// <summary>
        /// Тип ремонта
        /// </summary>
        [EnumDataType(typeof(TypeOfRepair))]
        [JsonConverter(typeof(JsonStringEnumConverter))]
        public TypeOfRepair TypeOfRepair { get; set; } = TypeOfRepair.None;
        /// <summary>
        /// Id дефектоскопа
        /// </summary>
        [Required]
        public Guid DefectoscopeId { get; set; }
        /// <summary>
        /// ID электроника
        /// </summary>
        [Required]
        public Guid EngineerID { get; set; }
    }
}
