using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryne.ReportingSystem.Application.Models
{
    public record RepairAndDefectoscopeDTO: RepairDTO
    {
        /// <summary>
        /// Серийный номер Дефектоскопа
        /// </summary>
        public string DefectoscopeSerialNumber { get; set; } = null!;
        /// <summary>
        /// тип дефектоскопа
        /// </summary>
        public string TypeOfDefectoscope { get; set; } = null!;
        /// <summary>
        /// Тип ремонта
        /// </summary>
        public string TypeOfRepairTostring { get; set; } = null!;
    }
}
