package mp3.utils;

import java.util.concurrent.Callable;

public class Exceptions {
	public static void printExpectedException(Callable<?> c) {
		try {
			c.call();
		} catch (Exception e) {
			System.out.println(Text.getIndent("Expected error: " + e.toString()));
		}
	}
}
