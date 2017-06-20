package com.mycrawler.demo;

import java.io.BufferedInputStream;
import java.io.BufferedOutputStream;
import java.io.File;
import java.io.FileOutputStream;
import java.io.IOException;
import java.io.InputStream;
import java.io.OutputStream;
import java.net.URL;

public class DownLoader extends Thread {
	private static InputStream is = null;
	private static OutputStream os = null;
	private static BufferedInputStream bis = null;
	private static BufferedOutputStream bos = null;
	private String str = "";
	public static int flag = 1;

	// 构造函数
	public DownLoader(String str) {
		this.str = str;
		System.out.println("网页" + str + "开始下载");
	}

	@Override
	public void run() {
		super.run();
		try {
			//Thread.sleep((long) (Math.random() * 100));
			final Object lock1 = new Object();
			synchronized (lock1) {
				System.out.println("开始下载文件" + flag);
				// 创建
				URL url = new URL(str);
				// 创建和对象
				is = url.openStream();
				os = new FileOutputStream(new File("E:/grap/" + flag + ".html"));// 文件保存为数字.html格式
				// 创建缓冲流和对象
				bis = new BufferedInputStream(is);
				bos = new BufferedOutputStream(os);
				// 创建字节数组
				byte[] bs = new byte[1024];
				int len = 0;
				// 循环读取网页内容到字符数组中，然后将字节数组中的内容写入到输出流中bos
				while ((len = bis.read(bs)) != -1) {
					bos.write(bs, 0, len);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			try {
				// 清空缓存，并关闭读取流
				bos.flush();
				bis.close();
				bos.close();
				System.out.println("文件" + flag + "下载完成");
				flag++;
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}
}
