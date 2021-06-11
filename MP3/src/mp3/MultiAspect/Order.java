package mp3.MultiAspect;

public class Order {
	protected float price;
	protected String cardNumber;
	protected PaymentMethod paymentMethod;
	
	protected OrderType type; 

	private Order(float price) {
		this.price = price;
	}
	
	protected Order(float price, String cardNumber, PaymentMethod paymentMethod, OrderType type) {
		this.price = price;
		this.cardNumber = cardNumber;
		this.paymentMethod = paymentMethod;
		this.type = type;
	}

	public float getPrice() {
		return price;
	}

	public void setPrice(float price) {
		this.price = price;
	}
	
	public static Order createPrepaymentOrder(float price, String cardNumber) {
		var order = new Order(price);
		order.type = OrderType.Prepayment;
		order.cardNumber = cardNumber;
		
		return order;
	}
	
	public static Order createPaymentOnPickupOrder(float price, PaymentMethod paymentMethod) {
		var order = new Order(price);
		order.type = OrderType.PaymentOnPickup;
		order.paymentMethod = paymentMethod;
		
		return order;
	}

	public String getCardNumber() throws Exception {
		if (this.type != OrderType.Prepayment) {
			throw new Exception("Order is not a prepayment");
		}

		return cardNumber;
	}

	public void setCardNumber(String cardNumber) throws Exception {
		if (this.type != OrderType.Prepayment) {
			throw new Exception("Order is not a prepayment");
		}

		this.cardNumber = cardNumber;
	}

	public PaymentMethod getPaymentMethod() throws Exception {
		if (this.type != OrderType.PaymentOnPickup) {
			throw new Exception("Order is not a payment on pickup");
		}

		return paymentMethod;
	}

	public void setPaymentMethod(PaymentMethod paymentMethod) throws Exception {
		if (this.type != OrderType.PaymentOnPickup) {
			throw new Exception("Order is not a payment on pickup");
		}

		this.paymentMethod = paymentMethod;
	}

	public OrderType getType() {
		return type;
	}
}
