using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Service.ExcelProcess
{
    public class ExcelService : IExcelService
    {
        public ExcelService() { }

        public List<Vehicle> VehicleProcess(IFormFile file)
        {
            return new List<Vehicle>();
        }

    }
}
