package mp3.utils;

public class Text {
	public static String getH1(String text) {
		return "\u001b[1;32m" + text + "\u001b[0m";
	}
	
	public static String getH2(String text) {
		return "\u001b[1;36m" + text + "\u001b[0m";
	}
	
	public static String getIndent(String text) {
		return "  " + text;
	}
}
