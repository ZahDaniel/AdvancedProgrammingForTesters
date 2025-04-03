namespace CourseClassLibrary.Domain.Car
{
    public class ToyotaCar : BaseCar
    {
        public string ModelSpecificFeature { get; }

        public ToyotaCar(string model, string brand, decimal price, string modelSpecificFeature)
            : base(model, brand, price)
        {
            if (string.IsNullOrWhiteSpace(modelSpecificFeature))
                throw new ArgumentException("Model-specific feature cannot be empty.");
            ModelSpecificFeature = modelSpecificFeature;
        }

        public override decimal CalculateAnnualTax() => Price * 0.02m; 

        public override string GetCarDetails() => $"{base.GetCarDetails()} - Feature: {ModelSpecificFeature}";
    }
}
