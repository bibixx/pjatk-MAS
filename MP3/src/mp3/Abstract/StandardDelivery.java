package mp3.Abstract;

public class StandardDelivery extends Delivery {
	private float tripLength;
	
	public StandardDelivery(String deliveryAddress, float tripLength) {
		super(deliveryAddress);
		
		this.tripLength = tripLength;
	}

	@Override
	public float calculateDeliveryPrice() {
		return this.tripLength * 3;
	}
}
