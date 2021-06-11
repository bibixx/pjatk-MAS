package mp3.MultiAspect;

public class OrderWithDelivery extends Order {
	private String address;
	
	public OrderWithDelivery(Order order, String address) {
		super(
			order.price,
			order.cardNumber,
			order.paymentMethod,
			order.type
		);

		this.address = address;
	}

	public String getAddress() {
		return address;
	}

	public void setAddress(String address) {
		this.address = address;
	}
}
