namespace CourseClassLibrary.Interfaces
{
    public interface ICar
    {
        string Model { get; }
        string Brand { get; }
        string LicensePlate { get; }
        decimal Price { get; }

        string GetCarDetails();
        decimal CalculateAnnualTax();
    }

}
