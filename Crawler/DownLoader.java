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

	// ���캯��
	public DownLoader(String str) {
		this.str = str;
		System.out.println("��ҳ" + str + "��ʼ����");
	}

	@Override
	public void run() {
		super.run();
		try {
			//Thread.sleep((long) (Math.random() * 100));
			final Object lock1 = new Object();
			synchronized (lock1) {
				System.out.println("��ʼ�����ļ�" + flag);
				// ����
				URL url = new URL(str);
				// �����Ͷ���
				is = url.openStream();
				os = new FileOutputStream(new File("E:/grap/" + flag + ".html"));// �ļ�����Ϊ����.html��ʽ
				// �����������Ͷ���
				bis = new BufferedInputStream(is);
				bos = new BufferedOutputStream(os);
				// �����ֽ�����
				byte[] bs = new byte[1024];
				int len = 0;
				// ѭ����ȡ��ҳ���ݵ��ַ������У�Ȼ���ֽ������е�����д�뵽�������bos
				while ((len = bis.read(bs)) != -1) {
					bos.write(bs, 0, len);
				}
			}
		} catch (Exception e) {
			e.printStackTrace();
		} finally {
			try {
				// ��ջ��棬���رն�ȡ��
				bos.flush();
				bis.close();
				bos.close();
				System.out.println("�ļ�" + flag + "�������");
				flag++;
			} catch (IOException e) {
				e.printStackTrace();
			}
		}
	}
}
