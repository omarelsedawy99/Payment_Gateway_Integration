using System;
namespace FactoryDesignPattern
{
    //Define the Product Interface
    public interface IPaymentGateway
    {
        void ProcessPayment(decimal amount);
    }
    //Concrete Implementations for the Products
    public class PayPalGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} payment through PayPal...");
            // Actual integration and logic for PayPal
        }
    }
    public class StripeGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} payment through Stripe...");
            // Actual integration and logic for Stripe
        }
    }
    public class CreditCardGateway : IPaymentGateway
    {
        public void ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing ${amount} payment using Credit Card...");
            // Logic for direct credit card processing
        }
    }
    //Factory Class to Produce the Products
    public static class PaymentGatewayFactory
    {
        public static IPaymentGateway CreatePaymentGateway(string gatewayName)
        {
            switch (gatewayName.ToLower())
            {
                case "paypal":
                    return new PayPalGateway();
                case "stripe":
                    return new StripeGateway();
                case "creditcard":
                    return new CreditCardGateway();
                default:
                    throw new ArgumentException("Invalid payment gateway specified");
            }
        }
    }

    // Testing the Factory Design Pattern
    public class Program
    {
        public static void Main()
        {
            Console.WriteLine("Select the payment gateway (PayPal, Stripe, CreditCard): ");
            string gatewayName = Console.ReadLine();
            try
            {
                IPaymentGateway paymentGateway = PaymentGatewayFactory.CreatePaymentGateway(gatewayName);
                paymentGateway.ProcessPayment(100.00M);  // Example amount
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine(ex.Message);
            }
            Console.ReadKey();
        }
    }
}