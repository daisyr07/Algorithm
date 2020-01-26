from tkinter import *
from tkinter import messagebox
import time
import numpy as np

class Good:
    def __init__(self, weight, value, status):
        self.weight = weight       # 物品的重量
        self.value = value         # 物品的价值
        self.status = status       # 物品是否被选中

class Bag():
    def __init__(self):
        # 第1步，实例化object，建立窗口root
        root = Tk()
        # 第2步，给窗口的可视化起名字
        root.title("背包问题")
        # 第3步，设定窗口的大小(长 x 宽)
        root.geometry('600x600')
        # 创建菜单栏
        menubar = Menu(root)
        root.config(menu=menubar)
        # 创建下拉菜单栏
        filemenu = Menu(menubar, tearoff = 0)
        menubar.add_cascade(label = "文件", menu = filemenu)
        filemenu.add_command(label = "退出", command = root.quit)
        # Frame 将问题1放在frame_1中
        frame_1 = Frame(root)
        frame_1.pack(fill = X)
        # 背包重量的输入
        label_backpack = Label(frame_1, text="物品总数量")
        label_backpack.grid(row=1, column=0)
        self.number = StringVar()
        number = Entry(frame_1, textvariable=self.number)
        # grid方法定位
        number.grid(row=1, column=1)

        label_number = Label(frame_1, text="背包承重量：：")
        label_number.grid(row=1, column=3)
        self.backpack = StringVar()
        backpack = Entry(frame_1, textvariable=self.backpack)
        backpack.grid(row=1, column=4)

        # Frame 将按钮放在frame_2中
        frame_2 = Frame(root)
        frame_2.pack(fill=X)
        Button(frame_2, text="动态规划", command=self.dynamic_show).grid(row=1, column=3)
        Button(frame_2, text = "贪心算法", command = self.green).grid(row = 1, column = 5)

        self.frame_3 = LabelFrame(root, text = "最大总价值")
        self.frame_3.pack(fill = BOTH, expand = YES)

        self.frame_4 = LabelFrame(root, text = "已装入物品")
        self.frame_4.pack(fill = BOTH, expand = YES)

        root.mainloop()

    def array_create(self):
        num = int(self.number.get())
        array = np.zeros((num), dtype=np.int)
        for i in range(num):
            array[i] += int(input())
        return array

    '''
    动态规划背包问题
    Parameters:
      num - 物品数量
      bag - 背包重量
      weigh - 每个物品的重量
      value - 每个物品的价值
    '''
    def dynamic(self):
        num = int(self.number.get())
        back = int(self.backpack.get())
        print(num)
        print("请输入每件物品的重量：")
        weight = self.array_create()
        print(weight)
        print("请输入每件物品的价值：")
        value = self.array_create()
        print(value)
        values = np.zeros((num + 1, back + 1), dtype=np.int)
        for i in range(1, num + 1):
            for j in range(1, back + 1):
                values[i][j] = values[i-1][j]
                if j >= weight[i - 1] and values[i][j] < values[i - 1][j - weight[i - 1]] + value[i - 1]:
                    values[i][j] = values[i - 1][j - weight[i - 1]] + value[i - 1]
        Label(self.frame_3, text = "动态规划表").grid(row = 1, column = 1)
        for i in range(len(values)):
            for j in range(len(values[i])):
                Label(self.frame_3, text = values[i][j]).grid(row = i+1, column = j)
        Label(self.frame_3, text = "最大价值是：").grid(row = num+3, column = 1)
        Label(self.frame_3, text = values[num][back]).grid(row = num+3, column = 3)
        return weight,values

    # 动态规划求解背包问题中所装的物品
    def dynamic_show(self):
        try:
            num = int(self.number.get())
            back = int(self.backpack.get())
        except:
            messagebox.showinfo(title='错误提示', message = "请输入整数")
        weight, values = self.dynamic()
        # 自动生成一个长度为num的一维数组，用于存放所装物品
        hold = np.zeros((num), dtype=np.int)
        j = back
        for i in range(num, 0, -1):
            if values[i][j] > values[i-1][j]:
                hold[i - 1] = 1
                j -= weight[i - 1]
        for i in range(num):
            if hold[i]:
                Label(self.frame_4, text = i+1).grid(row = 1, column = i)
    
    def green(self):
        print("C:")
        weights = int(self.backpack.get())
        consequence = []
        sum = 0
        
Bag()
