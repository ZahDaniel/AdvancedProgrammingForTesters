namespace PaymentProcessorTests
{
    public class PaymentProcessorUnitTests
    {
        private readonly PaymentProcessor _paymentProcessor;

        public PaymentProcessorUnitTests()
        {
            _paymentProcessor = new PaymentProcessor();
        }

        [Fact]
        public void ProcessPayment_CreditCard_ShouldReturnCorrectMessage()
        {
            // Arrange
            var paymentAmount = 100.00;
            var paymentMethod = "CreditCard";

            // Act
            var result = _paymentProcessor.ProcessPayment(paymentMethod, paymentAmount);

            // Assert
            Assert.Equal($"Processing Credit Card payment of ${paymentAmount}...", result);
        }

        [Fact]
        public void ProcessPayment_BankTransfer_ShouldReturnCorrectMessage()
        {
            // Arrange
            var paymentAmount = 200.00;
            var paymentMethod = "BankTransfer";

            // Act
            var result = _paymentProcessor.ProcessPayment(paymentMethod, paymentAmount);

            // Assert
            Assert.Equal($"Processing Bank Transfer payment of ${paymentAmount}...", result);
        }
    }
}