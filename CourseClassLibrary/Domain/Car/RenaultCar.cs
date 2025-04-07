using CourseClassLibrary.Interfaces;

namespace CourseClassLibrary.Domain.Car
{
    public class RenaultCar : ICar
    {
        public string Model { get; }
        public string Brand { get; }
        public string LicensePlate { get; }
        public decimal Price { get; }

        public string ModelSpecificFeature { get; }

        public RenaultCar(string model, string brand, string licensePlate, decimal price, string modelSpecificFeature)
        {
            Model = model;
            Brand = brand;
            LicensePlate = licensePlate;
            Price = price;
            ModelSpecificFeature = modelSpecificFeature;
        }

        public decimal CalculateAnnualTax() => Price * 0.02m; // Example tax rate for Renault

        public string GetCarDetails() => $"{Brand} {Model} - Feature: {ModelSpecificFeature} and {Price}";
    }
}