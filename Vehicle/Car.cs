namespace Vehicles
{
    public class Car
    {
        static int idCounter = 0;
        public int Id { get; set; }
        public string Manufacturer { get; set; }

        public string Model { get; set; }

        public float Price { get; set; }

        public DateTime ProductionDate { get; set; }

        public Car(string manufacturer, string model, float price, DateTime productionDate)
        {
            Id = idCounter++;
            Manufacturer = manufacturer;
            Model = model;
            Price = price;
            ProductionDate = productionDate;
        }

        public static List<Car> GenerateCars() 
        {
            return new List<Car>
            {
                new Car("Porche", "Panamera", 82000, new DateTime(2018,1,1)),
                new Car("BMW", "M4 coupe", 90000, new DateTime(2022,1,1)),
                new Car("BMW", "M5", 125000, new DateTime(2022,1,1)),
                new Car("Mercedes", "C class coupe", 35000, new DateTime(2019,1,1)),
                new Car("Audi", "A1", 12000, new DateTime(2016,1,1)),
                new Car("Volkswagen", "Golf", 28000, new DateTime(2021,1,1)),
                new Car("Volkswagen", "ID.4", 55000, new DateTime(2022,1,1)),
            }; 
        }

        public override string? ToString()
        {
            return $"Car => Manufacutrer: {Manufacturer}, Model: {Model}, Price: {Price}, Profuction date: {ProductionDate.Year}";
        }
    }
}