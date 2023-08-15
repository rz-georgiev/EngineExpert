namespace EngineExpert.Data.Models
{
    public class Car : BaseModel
    {
        public string Brand { get; set; }

        public string Model { get; set; }

        public int HorsePowers { get; set; }

        public int EuroStandard { get; set; }

        public int Year { get; set; }

        public int CarTypeId { get; set; }

        public int EngineTypeId { get; set; }

        public int ShiftTypeId { get; set; }

        public string Color { get; set; }

        public CarType CarType { get; set; }

        public EngineType EngineType { get; set; }

        public ShiftType ShiftType { get; set; }
    }
}