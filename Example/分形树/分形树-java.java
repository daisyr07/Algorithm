package design;

import javax.swing.*; //导入javax里面的swing包，以javax开头的意思是，后面导入的包，是标准扩展库集。由它导入的包能在多个java版本中使用 
import java.awt.*;//导入java里面的awt包，graphics所在的包
import java.util.ArrayList;
import java.util.List;

public class Tree extends JFrame{    //tree继承JFrame
	// 先垂直绘制一根线段，然后在线段顶端向右一定倾角绘制一根线段，长度分别为原线段的k倍.    
	// 再同样的，在线段左侧以固定倾角绘制一根线段，如此反复，直至线段长度小于某个较小的值。  
	// 其中，线条的颜色以及长度，夹角（例如产生某个范围的随机数）都可以自行进行微调。  
	     
		// 表示生成的窗体大小可改变        setResizable(true);      
	// 结束窗口所在的应用程序。在窗口被关闭的时候会退出JVM        
	 
	//graphics是个抽象类，它的对象是用来传给drawTree（）方法作为画笔来画出分型树
	//drawTree方法用Graphics的对象g作为参数

	
	public Tree(){
		setTitle("分形树");
		add(new DrawTree(400, 10));
	}
	public static void main(String[] args){
		Tree jFrame = new Tree();//构造一个树
		//jFrame.setLocationRelativeTo(null);//窗口设置屏幕中央
		jFrame.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);//EXIT_ON_CLOSE：结束窗口所在的应用程序
		jFrame.setSize(500,500);//控件的宽度和高度
		jFrame.setLocation(700, 400);//将组件移到新位置，400和200来指定新位置的左上角
		jFrame.setVisible(true);//设置图形界面为可见，一般默认是不可见的
	}

}


class DrawTree extends JComponent {
	private int min;
	private List<ArrayList<Integer>> points = new ArrayList<>();
	private ArrayList<Integer> xList = new ArrayList<Integer>();
	private ArrayList<Integer> yList = new ArrayList<Integer>();

	public DrawTree(int max,int min){
		this.min = min;
		getPoint(250,460,max,0.0);
	}

	public void paint(Graphics g) {
		super.paintComponent(g);//绘制父类对像的界面，只修改其中部分展示效果
		for(int i=0;i< points.get(0).size();i+=2){
			g.drawLine(points.get(0).get(i), points.get(1).get(i), points.get(0).get(i+1), points.get(1).get(i+1));
		}

	}

	private void getPoint(int x,int y,int max1,double ee){
	
		if(max1<=min){
			points.add(xList);
			points.add(yList);
			return;
		}
		else{
			xList.add(x);
			yList.add(y);

			int x1 = (int) (max1*Math.cos(Math.PI/2-ee)+x);//max1是支的长度
			int y1 = (int) (y-max1*Math.sin(Math.PI/2-ee));

			xList.add(x1);
			yList.add(y1);

			int maxRight = max1*2/3;
			int x2 = x+(x1-x)/3;
			int y2 = y-(y-y1)/3;
			double e1 = ee+Math.PI/6;
			int maxLeft = max1/3;
			int x3 = x+(x1-x)*2/3;
			int y3 = y-(y-y1)*2/3;
			double e2 = ee-Math.PI/6;
		
			
			getPoint(x2,y2,maxRight,e1);
			getPoint(x3,y3,maxLeft,e2);
		}
	}

}

//室友写的
