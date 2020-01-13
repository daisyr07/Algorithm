template<class VertexType>
struct VNode{
	VertexType data;             //顶点数据元素之值
	List<int> arc_list;          //由弧组成的线性表
};


template<class VertexType,int max_size>
class Digraph {
public:
	//构造函数
	Digraph();
	//析构函数，释放内存空间
	~Digraph();
	//确定数据元素的值为item的序号
	int locate_vex(const VertexType &item);       
	//返回图的顶点个数
	int vex_num();       
	//求顶点v的数据元素值
	Error_code get_vex(int v,VertexType &item);    
	//设置顶点v的数据元素值
	Error_code put_vex(int v,const VertexType &item);    
	//求顶点v的第i个邻接点 
	Error_code adj_vex(int v,int i,int &adj_point);
	//插入数据元素值为item的顶点
	Error_code insert_vex(const VertexType &item);
	//插入顶点序号分别为v,w的弧
	Error_code insert_arc(int v,int w);
	//删除顶点序号为v的顶点
	Error_code remove_vex(int v);
	//删除顶点序号分别为v,w的弧
	Error_code remove_arc(int v,int w);
protected:
	int count;    //顶点数，最多为max_size
	VNode<VertexType> vertices[max_size]; 
	//求元素值为entry的结点序号(-1表示失败)
	int index(const List<int> &l,int entry); 
};
   

template<class VertexType,int max_size>
Digraph<VertexType,max_size>::Digraph()
{   //构造函数 
	count = 0;
}


template<class VertexType,int max_size>
Digraph<VertexType,max_size>::~Digraph()
{   //析构函数，释放内存空间
	int v;
	for(v=0;v<count;v++)
		vertices[v].arc_list.clear();
}


template<class VertexType,int max_size>
int Digraph<VertexType,max_size>::locate_vex(const VertexType &item)
{   //确定数据元素的值为item的序号
	int position=0;
	while(position<count && vertices[position].data!=item)position++;
	if(position<count)return position;   //定位成功
	else return -1;                      //定位失败
}


template<class VertexType,int max_size>
int Digraph<VertexType,max_size>::vex_num()
{   //返回图的顶点个数
	return count;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::get_vex(int v,VertexType &item)
{   //求顶点v的数据元素值
	if(v<count){
		item=vertices[v].data;
		return success;
	}
	else return range_error;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::put_vex(int v,const VertexType &item)
{   //设置顶点v的数据元素值
	if(v<count){
		vertices[v].data=item;
		return success;
	}
	else return range_error;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::adj_vex(int v,int i,int &adj_point)
{   //求顶点v的第i个邻接点 
	if(v<count)return vertices[v].arc_list.retrieve(i,adj_point);
	else return range_error;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::insert_vex(const VertexType &item)
{   //插入数据元素值为item的顶点
	if(count<max_size){
		if(locate_vex(item)==-1){
			vertices[count++].data=item;
			return success;
		}
		else return duplicate;
	}
	else return overflow;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::insert_arc(int v,int w)
{   //插入顶点序号分别为v,w的弧
	if(v<count && w<count){
		if(index(vertices[v].arc_list,w)!=-1)
			return duplicate;
		else{
			vertices[v].arc_list.insert(vertices[v].arc_list.size(),w);
			return success;
		}
	}
	else return range_error;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::remove_vex(int v)
{   //删除顶点序号为v的顶点
	if(v<count){
		vertices[v].arc_list.clear();
		for(int i=v+1;i<count;i++)
			vertices[i-1]=vertices[i];
		count--;
		return success;
	}
	else return range_error;
}


template<class VertexType,int max_size>
Error_code Digraph<VertexType,max_size>::remove_arc(int v,int w)
{   //删除顶点序号分别为v,w的弧
	int position,x;
	if(v<count && w<count){
		if((position=index(vertices[v].arc_list,w))!=-1){
			vertices[v].arc_list.remove(position,x);
			return success;
		}
		else return fail;
	}
	else return range_error;
}


template<class VertexType,int max_size>
int Digraph<VertexType,max_size>::index(const List<int> &l,int entry)
{   //求元素值为entry的结点序号
	int x, position=0;
	while(l.retrieve(position,x)==success && (x!=entry))position++;
	if(position<l.size())return position;
	else return -1;
}

