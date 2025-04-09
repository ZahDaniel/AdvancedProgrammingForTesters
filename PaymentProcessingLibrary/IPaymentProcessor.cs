using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentProcessingLibrary
{
    public interface IPaymentProcessor
    {
        string Process(double amount);
    }
}
