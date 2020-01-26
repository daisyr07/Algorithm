import turtle as t

#绘制
def draw_tree(tree_len,tree_angle):
    t.speed(1) #设置绘画的速度
    #设置长度
    l=tree_len/3 #绘制的长度的1/3

    if tree_len > 50:#终止条件
        #主干线段的绘制
        t.forward(tree_len)#向前画
        t.backward(l)  #往后退l长度

         #左分支绘制
        t.left(tree_angle)   #向左转角度
        t.forward(l)
        t.backward(l)
        draw_tree(l,tree_angle)

        t.right(tree_angle)   #转回正方向
        t.backward(l)

        #右分支绘制
        t.right(tree_angle)    #向右转角度
        t.forward(l*2)
        t.backward(l*2)
        draw_tree(l*2,tree_angle)

        t.left(tree_angle)    #转回正方向
        t.backward(l)

def main():
    t.screensize(600,700,'Antiquewhite')#设置画布的宽高背景颜色
    # t.setup(600,700) # 设置绘画窗口的宽度高度
    t.title("分形树")
    t.mode('logo')   #设置方向为正北
    t.penup()   #起笔
    t.color('Saddlebrown')#设置树的颜色
    t.pensize(5)#设置绘画笔的宽度
    t.backward(250)#把起点放到底部
    t.pendown()   #下笔
    tree_len=360   #树干的初始长度
    tree_angle = 60   #树干的角度
    draw_tree(tree_len,tree_angle)
    t.exitonclick()  #点击才关闭画画窗口


if __name__=='__main__':
    main()
