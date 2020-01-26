full=8#满瓶容量
a=5#第一瓶容量
b=3#第二瓶容量
i=4#称量目标
def pullwater(full1,a1,b1,i):
    x=0#实际第一瓶量
    y=0#实际第二瓶量
    z=full1#实际满瓶量
    while z!=i or x!=i and y!=i:#判断是否量出目标量，否就循环
        if x==0:#第一瓶为空
            z-=a1#满瓶倒入第一瓶
            x=a1
        elif y==b1:#第二瓶满，第二瓶倒入满瓶
            z+=y
            y=0
        elif x>b1-y:#第一瓶的实际量大于第二瓶的空量，第一瓶把第二瓶倒满，但自己还有剩余
            x-=b1-y
            y=b1
        else:#否则第一瓶全部倒入第二瓶，第一瓶为空
            y+=x
            x=0
        print('第一瓶：',x,'\t第二瓶：',y,'\t满瓶：',z)
pullwater(full,a,b,i)