package mp3.Abstract;

public class ExpressDelivery extends Delivery {	
	private float timeForDelivery; 

	public ExpressDelivery(String deliveryAddress, float timeForDelivery) {
		super(deliveryAddress);
		
		this.timeForDelivery = timeForDelivery;
	}

	public float getTimeForDelivery() {
		return timeForDelivery;
	}

	public void setTimeForDelivery(float timeForDelivery) {
		this.timeForDelivery = timeForDelivery;
	}

	@Override
	public float calculateDeliveryPrice() {
		return 1 / (timeForDelivery / 60) * 20;
	}
}
