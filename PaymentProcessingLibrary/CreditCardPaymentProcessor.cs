namespace PaymentProcessingLibrary
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
    {
        public string Process(double amount)
        {
            return $"Processing Credit Card payment of ${amount}...";
        }
    }
}
