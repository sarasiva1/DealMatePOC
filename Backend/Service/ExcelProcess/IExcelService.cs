using DealMate.Backend.Domain.Aggregates;

namespace DealMate.Backend.Service.ExcelProcess;

public interface IExcelService
{
    List<Vehicle> VehicleProcess(IFormFile file);
}
