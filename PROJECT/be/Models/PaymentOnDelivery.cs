namespace mas_project.Models
{
    public enum PaymentOnDeliveryMethod {
        Cash,
        CreditCard
    }

	public partial class PaymentOnDelivery : PaymentMethod
    {
        public PaymentOnDeliveryMethod PaymentMethod { get; set; }
    }
}
