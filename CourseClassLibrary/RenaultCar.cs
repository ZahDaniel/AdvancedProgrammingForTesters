namespace CourseClassLibrary
{
    public class RenaultCar : BaseCar
    {
        public string ModelSpecificFeature { get; }

        public RenaultCar(string model, string brand, decimal price, string modelSpecificFeature)
            : base(model, brand, price)
        {
            if (string.IsNullOrWhiteSpace(modelSpecificFeature))
                throw new ArgumentException("Model-specific feature cannot be empty.");
            ModelSpecificFeature = modelSpecificFeature;
        }

        public override decimal CalculateAnnualTax() => Price * 0.02m; // Example tax rate for Renault

        public override string GetCarDetails() => $"{base.GetCarDetails()} - Feature: {ModelSpecificFeature}";
    }
}
