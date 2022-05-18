using Ryne.ReportingSystem.Entity;

namespace Ryne.ReportingSystem.Application
{
    /// <summary>
    /// Создание документов Excel, Word
    /// </summary>
    public class CreateDocuments
    {
        private readonly Defectoscope _defectoscope;

        public CreateDocuments(Defectoscope defectoscope)
        {
            _defectoscope = defectoscope;
        }

        public void CreateActOfRepairWork()
        {
            
        }
    }
}
