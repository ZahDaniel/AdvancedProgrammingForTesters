using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessingLibrary 
{
    public class CreditCardPaymentProcessor : IPaymentProcessor
{
    public string Process(double amount)
    {
        // Simulate credit card payment processing
        return $"Processed credit card payment of {amount:C}";
    }
}
}

