using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application
{
    // TODO: избавится от привязки напрямую к классам
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
        public DefectoscopeBuilder AddTypeOfDefectoscope(TypeOfDefectoscope typeOfDefectoscope)
        {
            _defectoscope.TypeOfDefectoscopeId = typeOfDefectoscope.Id;
            _defectoscope.TypeOfDefectoscope = typeOfDefectoscope;
            return this;
        }
        public DefectoscopeBuilder AddOrganization(Organization organization)
        {
            _defectoscope.OrganizationId = organization.Id;
            _defectoscope.Organization = organization;
            return this;
        }
        public DefectoscopeBuilder AddRepair(Repair repair)
        {
            _defectoscope.Repairs.Add(repair);
            return this;
        }
        public DefectoscopeBuilder AddProductionYear(uint year)
        {
            _defectoscope.ProductionYear = year;
            return this;
        }
        public Defectoscope Build()
        {
            return _defectoscope;
        }
    }

}