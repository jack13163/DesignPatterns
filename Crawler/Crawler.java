package com.mycrawler.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.PrintStream;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Crawler {
	public static void main(String[] args) throws InterruptedException, FileNotFoundException {
		// 即将要访问的url
		String visitingUrl = "http://www.sina.com.cn/";
		String visitingFile = "E:/grap/1.html";
		//新建url仓库
		Storage urlStorage = new Storage();
		urlStorage.EnQueue(visitingUrl);
		//新建文件仓库
		Storage fileStorage = new Storage();
		fileStorage.EnQueue(visitingFile);

		// 读取url的文件
		String content = "";

		// 规则
		// String regx = "http://([\\w]+.?)*([\\w]/)*\\b";//自己编写
		String regx2 = "[http]{4}\\:\\/\\/([a-zA-Z]|[0-9])*(\\.([a-zA-Z]|[0-9])*)*(\\/([a-zA-Z]|[0-9])*)*\\s?";// 网上抄写
		Pattern pattern = Pattern.compile(regx2);

		// 设置日志输出
		PrintStream ps = new PrintStream(new FileOutputStream("E:/log/log.txt"));
		System.setOut(ps);
		// 设置错误信息输出
		PrintStream ps2 = new PrintStream(new FileOutputStream(new File("E:/log/error.txt")));
		System.setErr(ps2);
		System.err.println("出错的信息是：");

		// 线程标示
		int flag = 1;
		// 线程开始
		while (urlStorage.unVisitedCount() != 0) {
			if (urlStorage.IsVisited(visitingUrl)) {
				System.out.println("此URL：" + visitingUrl + "被重复访问了");
				// 当所有未访问的都已访问，终止
				if (urlStorage.unVisitedCount() == 0) {
					System.out.println("url队列为空");
					break;
				}
			}
			// 当前主线程等待1s
			// Thread.sleep(1000);
			// 获取即将访问的url，并完成出队
			visitingUrl = urlStorage.Dequeue();
			// 输出日志信息到log.txt文件中
			System.out.println("正在访问" + visitingUrl);
			// 判断即将访问的url是否为空，如果为空，就不进行接下来的下载工作
			if (visitingUrl != "") {
				// 根据URL来下载网页，线程启动
				DownLoader dl1 = new DownLoader(visitingUrl);
				dl1.start();
				System.out.println("线程" + flag + "启动");
				dl1.join();
				System.out.println("线程" + flag + "停止");
				// 下一个线程的标示增加1
				flag++;
				//已下载文件入队
				fileStorage.EnQueue(visitingFile);
			}
			// 获取下一个文件中的url队列
			while (urlStorage.unVisitedCount() == 0) {
				System.out.println("查找文件：" + visitingFile);
				// 如果文件未被访问过，代表url还没有全部入库
				if(!fileStorage.IsVisited(visitingFile)){
					// 读取下一个文件
					content = Reader.getContent(visitingFile);
					// 创建匹配器
					Matcher matcher = pattern.matcher(content);
					// 新文件中的url入队
					while (matcher.find()) {
						String a = matcher.group();
						urlStorage.EnQueue(a);
						System.out.println("url" + a + "入队");
					}
					System.out.println("文件" + visitingFile + "中的url已全部入队！");
					//文件中的url已经被全部入库，文件可以出队了，进入垃圾堆set集合
					fileStorage.Dequeue();
					break;
				}
				System.out.println("文件：" + visitingFile + "不存在！");
			}
			// 下一个要访问的url
			visitingUrl = urlStorage.next();
		}
		System.out.println("全部工作已完成！");
	}
}
