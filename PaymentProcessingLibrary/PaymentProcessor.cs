public class PaymentProcessor
{
    public string ProcessPayment(string paymentMethod, double amount)
    {
        if (paymentMethod == "CreditCard")
        {
            return $"Processing Credit Card payment of ${amount}...";
        }
        else if (paymentMethod == "BankTransfer")
        {
            return $"Processing Bank Transfer payment of ${amount}...";
        }
        else
        {
            return "Unsupported payment method.";
        }
    }
}