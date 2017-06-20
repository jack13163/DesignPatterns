package com.mycrawler.demo;

import java.util.ArrayList;
import java.util.HashSet;
import java.util.List;
import java.util.Set;

public class Storage {
	/**
	 * 仓库
	 */
	// 未访问过的
	private final List<String> unvisited = new ArrayList<String>();
	// 已访问过的
	private final Set<String> visited = new HashSet<String>();

	// 入队
	public boolean EnQueue(String url) {
		unvisited.add(url);
		return true;
	}
	// 出队，已经访问过的进入（垃圾堆）集合
	public String Dequeue() {
		String v = unvisited.remove(0);
		visited.add(v);
		return v;
	}
	// 是否已经访问过了
	public boolean IsVisited(String str) {
		if (visited.contains(str)) {
			return true;
		}else{
			return false;
		}
	}
	//未访问的数量
	public int unVisitedCount(){
		return unvisited.size();
	}
	//返回第一个url
	public String next(){
		if(unvisited.size()>0){
			return unvisited.get(0);
		}
		return "";
	}
	//返回集合
	public String[] allVisited(){
		return (String[])visited.toArray();
	}
}
