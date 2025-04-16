using PaymentProcessingLibrary;

namespace PaymentProcessorTests
{
    public class PaymentProcessorUnitTests
    {
        private readonly PaymentProcessor _paymentProcessor;
        private readonly CreditCardPaymentProcessor _creditCardPaymentProcessor; // Added missing field
        private readonly BankTransferPaymentProcessor _bankTransferPaymentPrcessor; // Added missing field

        public PaymentProcessorUnitTests()
        {
            _paymentProcessor = new PaymentProcessor();
            _creditCardPaymentProcessor = new CreditCardPaymentProcessor();
            _bankTransferPaymentPrcessor = new BankTransferPaymentProcessor();
        }

        [Fact]
        public void ProcessPayment_CreditCard_ShouldReturnCorrectMessage()
        {
            // Arrange
            var paymentAmount = 100.00;

            // Act
            var result = _creditCardPaymentProcessor.Process(paymentAmount);

            // Assert
            Assert.Equal($"Processing Credit Card payment of ${paymentAmount}...", result);
        }

        [Fact]
        public void ProcessPayment_BankTransfer_ShouldReturnCorrectMessage()
        {
            // Arrange
            var paymentAmount = 200.00;

            // Act
            var result = _bankTransferPaymentPrcessor.Process(paymentAmount);

            // Assert
            Assert.Equal($"Processing Bank Transfer payment of ${paymentAmount}...", result);
        }
    }
}