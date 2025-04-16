using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessingLibrary
{
    public class BankTransferPaymentProcessor : IPaymentProcessor
    {
        public string Process(double amount)
        {
           return $"Processed bank transfer payment of {amount:C}";
        }
    }
}
