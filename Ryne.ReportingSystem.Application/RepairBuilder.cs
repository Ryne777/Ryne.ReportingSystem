using Ryne.ReportingSystem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ryne.ReportingSystem.Application
{
    /// <summary>
    /// Строитель ремонтов
    /// </summary>
    public class RepairBuilder
    {
        private readonly Repair _repair = new();

        
        public RepairBuilder AddDateReceipt(DateTime dateOfReceipt)
        {
            _repair.DateOfReceipt = dateOfReceipt;
            return this;
        }
        public RepairBuilder AddDateRelease(DateTime dateOfRelease)
        {
            _repair.DateOfRelease = dateOfRelease;
            return this;
        }
        public RepairBuilder AddDateOfCalibration(DateTime dateOfCalibration)
        {
            _repair.DateOfCalibration = dateOfCalibration;
            return this;
        }
        public RepairBuilder AddDateOfLastRepair(DateTime dateOfLastRepair)
        {
            _repair.DateOfLastRepair = dateOfLastRepair;
            return this;
        }
        public RepairBuilder AddTypeOfRepair(TypeOfRepair typeOfRepair)
        {
            _repair.TypeOfRepair = typeOfRepair;
            return this;
        }
        public RepairBuilder AddEngineer(Engineer engineer)
        {
            _repair.EngineerID = engineer.Id;
            _repair.Engineer = engineer;
            return this;
        }
        public Repair Bulid()
        {
            return _repair;
        }
    }
}
