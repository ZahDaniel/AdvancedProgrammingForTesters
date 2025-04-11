namespace PaymentProcessingLibrary
{
    public interface IPaymentProcessor
    {
        string Process(double amount);
    }
}
