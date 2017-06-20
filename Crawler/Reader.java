package com.mycrawler.demo;

import java.io.BufferedReader;
import java.io.File;
import java.io.FileReader;

public class Reader {
	public static String filename;

	@SuppressWarnings("unused")
	public static String getContent(String filename) {
		StringBuilder content = new StringBuilder();
		String str = "";
		try {
			FileReader fileReader = new FileReader(new File(filename));
			@SuppressWarnings("resource")
			BufferedReader br = new BufferedReader(fileReader);
			while ((str = br.readLine()) != null) {
				content.append(str);
			}
		} catch (Exception e) {
			e.printStackTrace();
		}
		if (content != null) {
			return content.toString();
		}else{
			return "";
		}
	}
}
