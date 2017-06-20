package com.mycrawler.demo;

import java.io.File;
import java.io.FileNotFoundException;
import java.io.FileOutputStream;
import java.io.PrintStream;
import java.util.regex.Matcher;
import java.util.regex.Pattern;

public class Crawler {
	public static void main(String[] args) throws InterruptedException, FileNotFoundException {
		// ����Ҫ���ʵ�url
		String visitingUrl = "http://www.sina.com.cn/";
		String visitingFile = "E:/grap/1.html";
		//�½�url�ֿ�
		Storage urlStorage = new Storage();
		urlStorage.EnQueue(visitingUrl);
		//�½��ļ��ֿ�
		Storage fileStorage = new Storage();
		fileStorage.EnQueue(visitingFile);

		// ��ȡurl���ļ�
		String content = "";

		// ����
		// String regx = "http://([\\w]+.?)*([\\w]/)*\\b";//�Լ���д
		String regx2 = "[http]{4}\\:\\/\\/([a-zA-Z]|[0-9])*(\\.([a-zA-Z]|[0-9])*)*(\\/([a-zA-Z]|[0-9])*)*\\s?";// ���ϳ�д
		Pattern pattern = Pattern.compile(regx2);

		// ������־���
		PrintStream ps = new PrintStream(new FileOutputStream("E:/log/log.txt"));
		System.setOut(ps);
		// ���ô�����Ϣ���
		PrintStream ps2 = new PrintStream(new FileOutputStream(new File("E:/log/error.txt")));
		System.setErr(ps2);
		System.err.println("�������Ϣ�ǣ�");

		// �̱߳�ʾ
		int flag = 1;
		// �߳̿�ʼ
		while (urlStorage.unVisitedCount() != 0) {
			if (urlStorage.IsVisited(visitingUrl)) {
				System.out.println("��URL��" + visitingUrl + "���ظ�������");
				// ������δ���ʵĶ��ѷ��ʣ���ֹ
				if (urlStorage.unVisitedCount() == 0) {
					System.out.println("url����Ϊ��");
					break;
				}
			}
			// ��ǰ���̵߳ȴ�1s
			// Thread.sleep(1000);
			// ��ȡ�������ʵ�url������ɳ���
			visitingUrl = urlStorage.Dequeue();
			// �����־��Ϣ��log.txt�ļ���
			System.out.println("���ڷ���" + visitingUrl);
			// �жϼ������ʵ�url�Ƿ�Ϊ�գ����Ϊ�գ��Ͳ����н����������ع���
			if (visitingUrl != "") {
				// ����URL��������ҳ���߳�����
				DownLoader dl1 = new DownLoader(visitingUrl);
				dl1.start();
				System.out.println("�߳�" + flag + "����");
				dl1.join();
				System.out.println("�߳�" + flag + "ֹͣ");
				// ��һ���̵߳ı�ʾ����1
				flag++;
				//�������ļ����
				fileStorage.EnQueue(visitingFile);
			}
			// ��ȡ��һ���ļ��е�url����
			while (urlStorage.unVisitedCount() == 0) {
				System.out.println("�����ļ���" + visitingFile);
				// ����ļ�δ�����ʹ�������url��û��ȫ�����
				if(!fileStorage.IsVisited(visitingFile)){
					// ��ȡ��һ���ļ�
					content = Reader.getContent(visitingFile);
					// ����ƥ����
					Matcher matcher = pattern.matcher(content);
					// ���ļ��е�url���
					while (matcher.find()) {
						String a = matcher.group();
						urlStorage.EnQueue(a);
						System.out.println("url" + a + "���");
					}
					System.out.println("�ļ�" + visitingFile + "�е�url��ȫ����ӣ�");
					//�ļ��е�url�Ѿ���ȫ����⣬�ļ����Գ����ˣ�����������set����
					fileStorage.Dequeue();
					break;
				}
				System.out.println("�ļ���" + visitingFile + "�����ڣ�");
			}
			// ��һ��Ҫ���ʵ�url
			visitingUrl = urlStorage.next();
		}
		System.out.println("ȫ����������ɣ�");
	}
}
