#include"Utility.h"
#include"Sq_queue.h"
#include"Lk_list.h"
#include"Adjacency_lists.h"
#include"Range_course.h"

void main(int argc, char *argv[])
{
	char infile_name[256],outfile_name[256];
	
	if (argc > 1) strcpy(infile_name,argv[1]);
	else strcpy(infile_name,"course_inf.txt");
	ifstream file_in(infile_name);    //  声明与打开输入流

    if (file_in == 0) {
		cout << "不能打开课程信息文件 " << infile_name << endl;
        exit (1);
    }
   
	if (argc > 2) strcpy(outfile_name,argv[2]);
	else strcpy(outfile_name,"curriculum_scedule.txt");
	ofstream file_out(outfile_name);   //  声明与打开输出流

    if (file_out == 0) {
		cout << "不能打开课程请文件 " << outfile_name << endl;
        exit (1);
    }

	cout<<"课程信息文件为: "<<infile_name<<endl<<endl;
	cout<<"正在排课，请稍候..."<<endl<<endl;

	//Range_Course<8,1000>表示排8学期课(从第1学期到第8学期),最多能对1000门课进行排课
	Range_Course<8,1000> rc(&file_in, &file_out);

	rc.read();               //输入课程信息
	rc.topological_order();  //用拓扑排的思进行排课
	rc.write();              //输出课表

	cout<<"排课结束，课表文件为: "<<outfile_name<<endl;
	cout<<"按任意退出"<<endl;
	getch();

}
