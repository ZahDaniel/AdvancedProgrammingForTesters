using CourseClassLibrary.Interfaces;

namespace CourseClassLibrary.Domain.Car
{
    public abstract class BaseCar : ICar
    {
        public string Model { get; }
        public string Brand { get; }
        public string LicensePlate { get; } = Guid.NewGuid().ToString().Substring(0, 8);
        public decimal Price { get; }

        protected BaseCar(string model, string brand, decimal price)
        {
            if (string.IsNullOrWhiteSpace(model)) throw new ArgumentException("Model cannot be empty.");
            if (string.IsNullOrWhiteSpace(brand)) throw new ArgumentException("Brand cannot be empty.");
            if (price <= 0) throw new ArgumentException("Price must be positive.");

            Model = model;
            Brand = brand;
            Price = price;
        }

        public virtual string GetCarDetails() => $"{Brand} {Model} (License: {LicensePlate}) - Price: {Price:C}";

        public abstract decimal CalculateAnnualTax();
    }
}
