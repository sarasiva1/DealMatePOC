using DealMate.Backend.Domain.Aggregates;
using DealMate.Backend.Infrastructure.Interfaces;
using DealMate.Backend.Service.Common;
using DealMate.Backend.Service.ExcelProcess;

namespace DealMate.Backend.Infrastructure.Repositories;

public class VehicleRepository : IVehicleRepository
{
    private readonly IRepository<Vehicle> repository;
    private readonly IExcelService excelService;
    public VehicleRepository(IRepository<Vehicle> repository, IExcelService excelService)
    {
        this.repository = repository;
        this.excelService = excelService;
    }

    public async Task<IEnumerable<Vehicle>> ExcelUpload(IFormFile file)
    {
        var vehicleList = excelService.VehicleProcess(file);
        var loadNo = vehicleList.First().LoadNo;
        var existVehicle = await this.repository.FindAsync(x=>x.LoadNo == loadNo);
        if (existVehicle.Count() != 0)
        {
            throw new Exception($"Already the Vehicles Load {loadNo} Uploaded");
        }
        return await this.repository.AddRangeAsync(vehicleList);
    }

    public async Task<Vehicle> Update(Vehicle vehicle)
    {
        var existvehicle = await repository.GetByIdAsync(vehicle.Id);
        if (existvehicle == null)
        {
            throw new Exception($"The VehicleID {vehicle.Id} not exist");
        }
        existvehicle.FrameNo = vehicle.FrameNo;
        existvehicle.FuelType = vehicle.FuelType;
        existvehicle.Key = vehicle.Key;
        existvehicle.SG = vehicle.SG;
        existvehicle.ManufactureDate = vehicle.ManufactureDate;
        existvehicle.Mirror = vehicle.Mirror;
        existvehicle.Tools = vehicle.Tools;
        existvehicle.ManualBook = vehicle.ManualBook;
        existvehicle = await repository.Update(existvehicle);
        return existvehicle;
    }

    public async Task<Vehicle> Delete(int id)
    {
        var vehicle = await repository.GetByIdAsync(id);
        if (vehicle == null)
        {
            throw new Exception($"The vehicle Id:{id} was not found");
        }
        vehicle = await repository.Remove(vehicle);
        return vehicle;
    }
}
