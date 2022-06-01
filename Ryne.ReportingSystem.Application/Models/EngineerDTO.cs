using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryne.ReportingSystem.Application.Models
{
    public record EngineerDTO :EngineerCreateDTO
    {
        public Guid Id { get; set; }
        /// <summary>
        /// Список произведенных ремонтов
        /// </summary>
        public virtual List<RepairAndDefectoscopeDTO>? Repairs { get; set; }
    }
}
