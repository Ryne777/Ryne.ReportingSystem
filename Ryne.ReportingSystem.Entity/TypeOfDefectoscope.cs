﻿using Ryne.ReportingSystem.Entity.Base;

namespace Ryne.ReportingSystem.Entity
{
    /// <summary>
    /// Тип
    /// </summary>
    public class TypeOfDefectoscope: Identity
    {
        public string Name { get; set; }
        public List<Defectoscope>? Defectoscopes { get; set; }

    }
}