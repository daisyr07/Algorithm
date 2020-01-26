import matplotlib.pyplot as plt
import math
import time
from tkinter import *

def draw_tree(x_start, y_start, length, angle):
    if length > 18:

        x_end = x_start + int(length * math.cos(math.radians(angle)))  # 通过起点，角度，长度算终点
        y_end = y_start + int(length * math.sin(math.radians(angle)))
        plt.plot([x_start, x_end], [y_start, y_end])  # 画树干(每次都画树干)

        # 画右子树
        x_point = x_start + (x_end - x_start) / 3  # 右树枝的起点
        y_point = y_start + (y_end - y_start) / 3
        draw_tree(x_point, y_point, int(length * 2 / 3), (angle - 30))

        # 画左子树
        x_point = x_start + 2 * (x_end - x_start) / 3  # 左树枝起点
        y_point = y_start + 2 * (y_end - y_start) / 3
        draw_tree(x_point, y_point, int(length * 1 / 3), (angle + 30))
    else:
        return 0


# plt.plot([-100, 100], [0, 0])  # x轴
# plt.plot([0, 0], [0, 150])  # y轴
start_time = time.process_time()
canvas = Canvas(width=525, height=300, bg='white') 
draw_tree(0, 0, 150, 90)
end_time = time.process_time()
print("\n程序运行时间：%f" % (end_time - start_time))
plt.show()