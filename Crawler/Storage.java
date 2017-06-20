package com.mycrawler.demo;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Storage {
	/**
	 * �ֿ�
	 */
	// δ���ʹ���
	private final List<String> unvisited = new ArrayList<String>();
	// �ѷ��ʹ���
	private final Set<String> visited = new HashSet<String>();

	// ���
	public boolean EnQueue(String url) {
		unvisited.add(url);
		return true;
	}
	// ���ӣ��Ѿ����ʹ��Ľ��루�����ѣ�����
	public String Dequeue() {
		String v = unvisited.remove(0);
		visited.add(v);
		return v;
	}
	// �Ƿ��Ѿ����ʹ���
	public boolean IsVisited(String str) {
		if (visited.contains(str)) {
			return true;
		}else{
			return false;
		}
	}
	//δ���ʵ�����
	public int unVisitedCount(){
		return unvisited.size();
	}
	//���ص�һ��url
	public String next(){
		if(unvisited.size()>0){
			return unvisited.get(0);
		}
		return "";
	}
	//���ؼ���
	public String[] allVisited(){
		return (String[])visited.toArray();
	}
}
