namespace CourseClassLibrary.Domain.Car
{
    public class HyundaiCar : BaseCar
    {
        public HyundaiCar(string model, string brand, decimal price) 
            : base(model, brand, price)
        {
        }

        public override string GetCarDetails() => $"{Brand} {Model} (License: {LicensePlate}) - Price: {Price:C}";

        public override decimal CalculateAnnualTax() => Price * 0.01m; // Example tax rate for Hyundai
    }
}