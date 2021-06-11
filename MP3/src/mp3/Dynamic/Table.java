package mp3.Dynamic;

public class Table {
	private int tableNumber;
	private int numberOfChairs;
	
	private Boolean isUnderUmbrella;
	private Boolean isInSmokingArea;

	private TableType type;
	
	private Table(int tableNumber, int numberOfChairs) {
		this.tableNumber = tableNumber;
		this.numberOfChairs = numberOfChairs;
	}
	
	public static Table createOutdoorsTable(int tableNumber, int numberOfChairs, boolean isUnderUmbrella) {
		var table = new Table(tableNumber, numberOfChairs);
		table.makeOutdoors(isUnderUmbrella);
		
		return table;
	}
	
	public void makeOutdoors(boolean isUnderUmbrella) {
		this.type = TableType.Outdoors;
		this.isUnderUmbrella = isUnderUmbrella;
		this.isInSmokingArea = null;
	}
	
	public static Table createIndoorsTable(int tableNumber, int numberOfChairs, boolean isInSmokingArea) {
		var table = new Table(tableNumber, numberOfChairs);
		table.makeIndoors(isInSmokingArea);
		
		return table;
	}
	
	public void makeIndoors(boolean isInSmokingArea) {
		this.type = TableType.Indoors;
		this.isInSmokingArea = isInSmokingArea;
		this.isUnderUmbrella = null;
	}

	public int getTableNumber() {
		return tableNumber;
	}

	public void setTableNumber(int tableNumber) {
		this.tableNumber = tableNumber;
	}

	public int getNumberOfChairs() {
		return numberOfChairs;
	}

	public void setNumberOfChairs(int numberOfChairs) {
		this.numberOfChairs = numberOfChairs;
	}

	public TableType getType() {
		return type;
	}

	public boolean getIsUnderUmbrella() throws Exception {
		if (this.type != TableType.Outdoors) {
			throw new Exception("Table is not outdoors");
		}

		return isUnderUmbrella;
	}

	public void setIsUnderUmbrella(boolean isUnderUmbrella) throws Exception {
		if (this.type != TableType.Outdoors) {
			throw new Exception("Table is not outdoors");
		}

		this.isUnderUmbrella = isUnderUmbrella;
	}

	public boolean getIsInSmokingArea() throws Exception {
		if (this.type != TableType.Indoors) {
			throw new Exception("Table is not indoors");
		}

		return isInSmokingArea;
	}

	public void setIsInSmokingArea(boolean isInSmokingArea) throws Exception {
		if (this.type != TableType.Indoors) {
			throw new Exception("Table is not indoors");
		}

		this.isInSmokingArea = isInSmokingArea;
	}
}
