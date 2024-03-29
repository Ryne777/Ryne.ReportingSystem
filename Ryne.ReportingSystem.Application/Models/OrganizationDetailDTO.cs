﻿namespace Ryne.ReportingSystem.Application.Models
{
    public record OrganizationDetailDTO: OrganizationDTO
    {
        /// <summary>
        /// Список пренадлежащих дефектосково
        /// </summary>
        public virtual List<DefectoscopeDTO>? Defectoscopes { get; set; }
    }
}
