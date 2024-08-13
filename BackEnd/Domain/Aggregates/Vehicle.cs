namespace DealMate.Backend.Domain.Aggregates
{
    public class Vehicle
    {
        public string? Make { get; set; }
        public string? Model { get; set; }
        public int? Year { get; set; } 
        public string? Color { get; set; }    
        public string? VIN { get; set; }      
        public double? Mileage { get; set; }
        public string? FuelType { get; set; }
    }
}
