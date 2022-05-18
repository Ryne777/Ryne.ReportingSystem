using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application
{
    /// <summary>
    /// Строитель дефектоскопов
    /// </summary>
    public class DefectoscopeBuilder
    {
        private readonly Defectoscope _defectoscope = new();

        public DefectoscopeBuilder AddSerialNumber(string serialNumber)
        {
            _defectoscope.SerialNumber = serialNumber;
            return this;
        }
        public DefectoscopeBuilder AddDateReceipt(DateTime dateOfReceipt)
        {
            _defectoscope.DateOfReceipt = dateOfReceipt;
            return this;
        }
        public DefectoscopeBuilder AddDateRelease(DateTime dateOfRelease)
        {
            _defectoscope.DateOfRelease = dateOfRelease;
            return this;
        }
        public DefectoscopeBuilder AddDateOfCalibration(DateTime dateOfCalibration)
        {
            _defectoscope.DateOfCalibration = dateOfCalibration;
            return this;
        }
        public DefectoscopeBuilder AddDateOfLastRepair(DateTime dateOfLastRepair)
        {
            _defectoscope.DateOfLastRepair = dateOfLastRepair;
            return this;
        }
        public DefectoscopeBuilder AddTypeOfRepair(TypeOfRepair typeOfRepair)
        {
            _defectoscope.TypeOfRepair = typeOfRepair;
            return this;
        }
        public DefectoscopeBuilder AddTypeOfDefectoscope(TypeOfDefectoscope typeOfDefectoscope)
        {
            _defectoscope.TypeOfDefectoscopelId = typeOfDefectoscope.Id;
            _defectoscope.TypeOfDefectoscope = typeOfDefectoscope;
            return this;
        }
        public DefectoscopeBuilder AddOrganization(Organization organization)
        {
            _defectoscope.OrganizationId = organization.Id;
            _defectoscope.Organization = organization;
            return this;
        }
    }

}