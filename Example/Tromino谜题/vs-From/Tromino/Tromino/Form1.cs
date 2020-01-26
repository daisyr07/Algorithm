using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tromino
{
    public partial class Form1 : Form
    {
        private bool caFlag = false;//bool类型判断颜色是否已经计算
        private int i = 1;//为棋盘上色时记数
        private int size = 4;//默认棋盘长度为4
        private int ptx = 1;//默认缺块的x坐标为1
        private int pty = 1;//默认缺块的y坐标为1
        private float sides = 100;//每个小格子的边长
        private int Lc= 0;
        private Graphics graphics;//图像类
        private PointF[] Board;//从Board[1]开始，每三个为一组，表示L型骨牌,[1][2][3]为同一个L型骨牌的坐标
        //Brushes笔刷，设置为系统定义颜色的Brush 对象，存放L型骨牌颜色
        private Brush[] brushes ={Brushes.AliceBlue,Brushes.Aquamarine,Brushes.Aqua,Brushes.Azure,
                                  Brushes.BlanchedAlmond, Brushes.Blue,Brushes.BurlyWood,Brushes.Beige,Brushes.BlueViolet,
                                   Brushes.Chartreuse,Brushes.Crimson,Brushes.Cornsilk,Brushes.Coral,Brushes.CadetBlue,
                                   Brushes.DarkKhaki,Brushes.DeepSkyBlue, Brushes.DarkOrchid,Brushes.DimGray, Brushes.DarkGoldenrod,                           
                                   Brushes.ForestGreen,Brushes.Goldenrod, Brushes.Gainsboro,Brushes.GhostWhite,
                                   Brushes.Honeydew, Brushes.IndianRed, Brushes.Indigo,Brushes.Ivory,Brushes.Khaki,
                                   Brushes.LightGray,Brushes.LightCoral,Brushes.Linen, Brushes.Lavender,
                                   Brushes.MediumPurple,Brushes.OliveDrab,Brushes.Orchid,Brushes.OrangeRed,
                                   Brushes.PaleGoldenrod,Brushes.Purple,Brushes.PaleTurquoise,       
          };
        private const float CHESSBOARD_SIZE = 512;//棋盘尺寸


        public Form1()
        {
            InitializeComponent();
            graphics = this.CreateGraphics(); //用于绘图的图像类
            domainUpDown1.Tag = true;
            textBoxX.Tag = true;
            textBoxY.Tag = true;
            Board = new PointF[size * size];
            Board[0] = new PointF(1, 1);//先初始化第0个，后续从1开始计数，每三个数算一个L型骨牌
            timer1.Enabled = false;
            this.buttonPrev.Enabled = false;
            this.buttonNext.Enabled = false;
        }

        //初始化form视图
        private void Form1_Shown(object sender, EventArgs e)
        {
            drawFrame();
        }

        /**覆盖棋盘
         * 通过缩小棋盘的size来改变棋盘大小，并用坐标定位的方式判断在几象限
         * 用缺块的坐标与象限坐标范围比较，判断缺块的位置，优先填充不含缺块的位置，使之构成L型
         * pointF,从Board[1]开始，每三个为一组，表示L型骨牌,[1][2][3]为同一个L型骨牌的坐标
         * sides = 100;//每个小格子的边长
         * 棋盘左下角的坐标(tx,ty)，缺块的坐标（dx,dy)
         * Lc代表使用L型骨牌个数，减去缺块，为（4~k-1）/3
         */
        private void fillChessboard(int tx, int ty, int dx, int dy, int size)
        {
            if (size == 1)//当且仅当size=1时，只有一个方块，是缺块
                return;
            ++Lc;
            int code = Lc;//骨牌号
            int i = 0;
            size = size / 2;
            //缺块在此象限,覆盖第二象限的子棋盘
            if (dx < tx + size && dy < ty + size)
            {
                //递归处理子棋盘直到左上角的子棋盘只剩一个时停止划分
                fillChessboard(tx, ty, dx, dy, size);
            }
            else
            {
                //右下角方块坐标放入棋盘表中，将子棋盘中相应位置设置为骨牌号，将无特殊方块的子棋盘转换为含有缺块的，此时无特殊方块的子棋盘各自的缺块组成一个新的L型骨牌
                Board[(code - 1) * 3 + (++i)] = new PointF(11 + (tx + size - 2) * sides, 11 + (ty + size - 2) * sides);
                //递归覆盖其余方格
                fillChessboard(tx, ty, tx + size - 1, ty + size - 1, size);
            }

            //缺块在此象限,覆盖第一象限的子棋盘
            if (dx >= tx + size && dy < ty + size)
            {
                fillChessboard(tx + size, ty, dx, dy, size);
            }
            else
            {
                Board[(code - 1) * 3 + (++i)] = new PointF(11 + (tx + size - 1) * sides, 11 + (ty + size - 2) * sides);
                fillChessboard(tx + size, ty, tx + size, ty + size - 1, size);
            }

            //缺块在此象限,覆盖第三象限的子棋盘
            if (dx < tx + size && dy >= ty + size)
            {
                fillChessboard(tx, ty + size, dx, dy, size);
            }
            else
            {
                Board[(code - 1) * 3 + (++i)] = new PointF(11 + (tx + size - 2) * sides, 11 + (ty + size - 1) * sides);
                fillChessboard(tx, ty + size, tx + size - 1, ty + size, size);
            }

            //缺块在此象限,覆盖第四象限的子棋盘
            if (dx >= tx + size && dy >= ty + size)
            {
                fillChessboard(tx + size, ty + size, dx, dy, size);
            }
            else
            {
                Board[(code - 1) * 3 + (++i)] = new PointF(11 + (tx + size - 1) * sides, 11 + (ty + size - 1) * sides);
                //Console.WriteLine("i = " + i.ToString());
                fillChessboard(tx + size, ty + size, tx + size, ty + size, size);
            }

        }

        //绘画
        private void drawFrame()
        {
            size = Convert.ToInt32(this.domainUpDown1.Text);
            sides = CHESSBOARD_SIZE / size;
            graphics.FillRectangle(Brushes.Gray, new RectangleF(10, 10, CHESSBOARD_SIZE, CHESSBOARD_SIZE));
            Pen pen = new Pen(Color.Black, 1);
            for (int i = 0; i <= size; ++i)
            {
                graphics.DrawLine(pen, 10 + i * sides, 10, 10 + i * sides, CHESSBOARD_SIZE + 10);
                graphics.DrawLine(pen, 10, 10 + i * sides, CHESSBOARD_SIZE + 10, 10 + i * sides);
            }
            graphics.FillRectangle(Brushes.Pink, new RectangleF(11 + (ptx - 1) * sides, 11 + (pty - 1) * sides, sides - 1, sides - 1));
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            if (i < size * size)
            {
                graphics.FillRectangle(brushes[i % 5], Board[i].X, Board[i].Y, sides - 1f, sides - 1f);
                graphics.FillRectangle(brushes[i % 5], Board[i + 1].X, Board[i + 1].Y, sides - 1f, sides - 1f);
                graphics.FillRectangle(brushes[i % 5], Board[i + 2].X, Board[i + 2].Y, sides - 1f, sides - 1f);
                i = i + 3;
            }
            else
            {
                i = 1;
                this.buttonStart.Text = "start";
                timer1.Enabled = false;
                this.domainUpDown1.Enabled = true;
                this.textBoxX.Enabled = true;
                this.textBoxY.Enabled = true;
            }

        }

  
        //开始按钮事件
        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (this.buttonStart.Text == "start")
            {
                drawFrame();
                i = 1;
                Lc = 0;
                this.buttonStart.Enabled = false;
                if (caFlag == false)
                {
                    Board = new PointF[size * size];
                    fillChessboard(1, 1, ptx, pty, size);
                    caFlag = true;
                }
                this.buttonStart.Text = "suspend";
                this.buttonStart.Enabled = true;
                timer1.Enabled = true;
                this.domainUpDown1.Enabled = false;
                this.textBoxX.Enabled = false;
                this.textBoxY.Enabled = false;
                this.buttonResult.Enabled = true;
                this.buttonPrev.Enabled = true;
                this.buttonNext.Enabled = true;
            }
            else if (this.buttonStart.Text == "suspend")
            {
                this.buttonStart.Text = "continue";
                timer1.Enabled = false;

            }
            else if (this.buttonStart.Text == "continue")
            {
                this.buttonStart.Text = "suspend";
                timer1.Enabled = true;
            }
        }

        //上一步按钮事件
        private void buttonPrev_Click(object sender, EventArgs e)
        {
            if (i >= 3)
            {
                i -= 3;
                graphics.FillRectangle(Brushes.PowderBlue, Board[i].X, Board[i].Y, sides - 1, sides - 1);
                graphics.FillRectangle(Brushes.PowderBlue, Board[i + 1].X, Board[i + 1].Y, sides - 1, sides - 1);
                graphics.FillRectangle(Brushes.PowderBlue, Board[i + 2].X, Board[i + 2].Y, sides - 1, sides - 1);
            }
        }

        //下一步按钮事件
        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (i <= size * size - 3)
            {
                graphics.FillRectangle(brushes[i % 20], Board[i].X, Board[i].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 1].X, Board[i + 1].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 2].X, Board[i + 2].Y, sides - 1, sides - 1);
                i += 3;
            }
        }

        //重新开始按钮事件
        private void buttonEnd_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            drawFrame();
            this.buttonStart.Text = "start";
            i = 1;
            Lc = 0;
            this.domainUpDown1.Enabled = true;
            this.textBoxX.Enabled = true;
            this.textBoxY.Enabled = true;
        }

        //结果按钮事件
        private void buttonResult_Click(object sender, EventArgs e)
        {
            timer1.Enabled = false;
            i = 1;
            Lc = 0;
            if (caFlag == false)
            {
                Board = new PointF[size * size];
                fillChessboard(1, 1, ptx, pty, size);
                caFlag = true;
            }
            while (i <= size * size - 3)
            {
                graphics.FillRectangle(brushes[i % 20], Board[i].X, Board[i].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 1].X, Board[i + 1].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 2].X, Board[i + 2].Y, sides - 1, sides - 1);
                i += 3;
            }
            this.buttonPrev.Enabled = true;
            this.buttonNext.Enabled = true;
            this.domainUpDown1.Enabled = true;
            this.textBoxX.Enabled = true;
            this.textBoxY.Enabled = true;
            this.buttonStart.Text = "start";
        }


        private void resultEvent()
        {
            timer1.Enabled = false;
            i = 1;
            Lc = 0;
            if (caFlag == false)
            {
                Board = new PointF[size * size];
                fillChessboard(1, 1, ptx, pty, size);
                caFlag = true;
            }
            while (i <= size * size - 3)
            {
                graphics.FillRectangle(brushes[i % 20], Board[i].X, Board[i].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 1].X, Board[i + 1].Y, sides - 1, sides - 1);
                graphics.FillRectangle(brushes[i % 20], Board[i + 2].X, Board[i + 2].Y, sides - 1, sides - 1);
                i += 3;
            }
            this.buttonPrev.Enabled = true;
            this.buttonNext.Enabled = true;
            this.domainUpDown1.Enabled = true;
            this.textBoxX.Enabled = true;
            this.textBoxY.Enabled = true;
            this.buttonStart.Text = "start";
        }
     
        //设置棋盘的长度
        private void domainUpDown1_SelectedItemChanged(object sender, EventArgs e)
        {
            this.buttonPrev.Enabled = false;
            this.buttonNext.Enabled = false;
            caFlag = false;
            DomainUpDown tb = (DomainUpDown)sender;
            //如果不是空
            if (tb.Text != "")
            {
                int num = Convert.ToInt32(tb.Text);
                //num必须是2的幂
                if ((num != 0 && (num & (num - 1)) == 0)&& num >= Convert.ToInt16(this.textBoxX.Text) && num >= Convert.ToInt16(this.textBoxY.Text))  
                {
                    //如果size，x，y 都有效 ，tag 为 true ，开始绘图
                    tb.Tag = true;
                    this.textBoxX.Tag = true;
                    this.textBoxY.Tag = true;
                    tb.BackColor = System.Drawing.SystemColors.Window;
                    vStart();
                    return;
                }
            }
            tb.Tag = false;
            vStart();
        }

        //缺块的X,Y处理
        private void textBox_TextChanged(object sender, EventArgs e)
        {
            this.buttonPrev.Enabled = false;
            this.buttonNext.Enabled = false;
            caFlag = false;
            TextBox tb = (TextBox)sender;
            if (tb.Text == "")
            {
                tb.Tag = false;
            }
            else if (Convert.ToInt32(tb.Text) > Convert.ToInt32(this.domainUpDown1.Text)||Convert.ToInt32(tb.Text)<=0)
            {
                tb.Tag = false;
                MessageBox.Show("错误！请修改初始块的坐标！");
                this.buttonStart.Enabled = false;
            }
            else
            {
                if (tb == this.textBoxX)
                {
                    ptx = Convert.ToInt32(tb.Text);
                }
                if (tb == this.textBoxY)
                {
                    pty = Convert.ToInt32(tb.Text);
                }
                tb.Tag = true;
            }
            vStart();
        }


        private void vStart()
        {
            this.buttonEnd.Enabled = this.buttonResult.Enabled
                = this.buttonStart.Enabled
                = (bool)domainUpDown1.Tag && (bool)textBoxX.Tag && (bool)textBoxY.Tag;
            if (this.buttonStart.Enabled == true)
                drawFrame();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.domainUpDown1.SelectedItem = this.domainUpDown1.Items[5];
            vStart();
            this.domainUpDown1.SelectedItem = this.domainUpDown1.Items[5];
        }
    }
}
