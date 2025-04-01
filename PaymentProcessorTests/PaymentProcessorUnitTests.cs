namespace PaymentProcessorTests
{
    public class PaymentProcessorUnitTests
    {
        public class PaymentProcessorTests
        {
            private readonly PaymentProcessor _paymentProcessor;

            public PaymentProcessorTests()
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
            public void ProcessPayment_PayPal_ShouldReturnCorrectMessage()
            {
                // Arrange
                var paymentAmount = 200.00;
                var paymentMethod = "PayPal";

                // Act
                var result = _paymentProcessor.ProcessPayment(paymentMethod, paymentAmount);

                // Assert
                Assert.Equal($"Processing PayPal payment of ${paymentAmount}...", result);
            }

        }
    }
}