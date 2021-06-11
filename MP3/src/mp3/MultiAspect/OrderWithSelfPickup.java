package mp3.MultiAspect;

import java.util.Date;

public class OrderWithSelfPickup extends Order {
	private Date pickupDate;
	
	public OrderWithSelfPickup(Order order, Date pickupDate) {
		super(
			order.price,
			order.cardNumber,
			order.paymentMethod,
			order.type
		);

		this.pickupDate = pickupDate;
	}

	public Date getPickupDate() {
		return pickupDate;
	}

	public void setPickupDate(Date pickupDate) {
		this.pickupDate = pickupDate;
	}
}
