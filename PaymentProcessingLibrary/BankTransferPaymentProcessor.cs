namespace PaymentProcessingLibrary
{
    public class BankTransferPaymentProcessor : IPaymentProcessor
    {
        public string Process(double amount)
        {
            return $"Processing Bank Transfer payment of ${amount}...";
        }
    }
}
