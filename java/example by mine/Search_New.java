package experiment.test2;
import java.util.Arrays;
import java.util.Scanner;
public class Search_New {
	static int x = input();
	static int y = input();
	public static void main(String[] args){
		timeBiSearch();
		timeSequentialSearch();
	}
	public static int binarySerach(int[] arr,int key){
		int min = 0;
		int max = arr.length-1;
		int mid = (min+max)/2;
		while(arr[mid] != key){
			if(arr[mid] < key){
				min = mid + 1;
			}else if(arr[mid] > key){
				max = mid - 1;
			}
			if(max < min){
				return -1;
			}
			mid = (min + max)/2;
		}
		return mid;
	}
	public static int sequentialSerach(int[] arr,int key){
		for (int i = 0; i < arr.length; i++) {
			if (arr[i] == key) {
				return i;
			}
		}
		return -1;
	}
	public static int[] random(int n,int max,int min){
		int arr[] = new int[n];
		for(int i = 0;i < arr.length;i++){
			arr[i] = (int)Math.round(Math.random()*(max-min)+min);
		}
		selectSort(arr);
		return arr;
	}
	public static void selectSort(int[] arr){
		for(int i = 0;i < arr.length;i++){
			for (int j = 0; j < arr.length-1; j++) {
				if (arr[i] < arr[j]) {
					int temp = arr[i];
					arr[i] = arr[j];
					arr[j] = temp;
				}
			}
		}
	}
	public static int input() {
		Scanner sc = new Scanner(System.in);
		System.out.println("请输入数组的长度：");
		int length = 0;
		try {
			length = sc.nextInt();
			if (length < 0) {
				System.out.println("请重新指定数组长度：");
				sc.next();
			}
		} catch (Exception e) {
			System.out.println("只能输入整数，请重新输入：");
			sc.next();
		}
		return length;
	}
	public static void timeSequentialSearch() {	
		long[] seArray = new long[100];
		int tm = 0;
		int max = 10000;
		int min = 10;
		int j = 0;
		int sum = 0;
		int avg = 0;
		int[] arr = random(x, max, min);
		if(y > arr.length){
			System.out.println("你输入的长度过长");
			return;
		}else{
			for(int i = 1;i < y;i++){
				int key = (int)Math.round(Math.random()*(max-min)+min);	
				long startTime=System.currentTimeMillis();
				int search = binarySerach(arr, key);
				long endTime=System.currentTimeMillis();
				if (search >= 0) {
//					System.out.println("你查找的"+key+"这个数，在数组的第"+search+"个位置");
				}else {
//					System.out.println("你查找的"+key+"这个数，没有在数组中");
				}
				tm += (endTime - startTime);
				if (j < seArray.length ) {
					seArray[j] = tm;
					j++;
				}
			}
			for (j = 0; j < seArray.length; j++) {
				sum += arr[j];
			}
			avg = sum / j;
		}
		System.out.println("已排好序的数组:"+Arrays.toString(arr));
		System.out.println("顺序查找所需要的平均时间是:"+avg+"ms");
	}
	
	public static void timeBiSearch() {	
		long[] biArray = new long[100];
		int tm = 0;
		int max = 10000;
		int min = 10;
		int j = 0;
		int sum = 0;
		int avg = 0;
		int[] arr = random(x, max, min);
//		for (int i = 1000; i < arr.length; i += 500) {
//			System.out.println("排序好的数组："+Arrays.toString(arr));
//
//		}
		if(y > arr.length){
			System.out.println("你输入的长度过长");
			return;
		}else{
			for(int i = 1;i < y;i++){
				int key = (int)Math.round(Math.random()*(max-min)+min);	
				long startTime=System.currentTimeMillis();
				int search = binarySerach(arr, key);
				long endTime=System.currentTimeMillis();
				if (search >= 0) {
//					System.out.println("你查找的"+key+"这个数，在数组的第"+search+"个位置");
				}else {
//					System.out.println("你查找的"+key+"这个数，没有在数组中");
				}
				tm += (endTime - startTime);
				if (j < biArray.length ) {
					biArray[j] = tm;
					j++;
				}
			}
			for (j = 0; j < biArray.length; j++) {
				sum += arr[j];
			}
			avg = sum / j;
		}
		System.out.println("已排好序的数组:"+Arrays.toString(arr));
		System.out.println("折半查找所需要的平均时间是:"+avg+"ms");
	}
}
