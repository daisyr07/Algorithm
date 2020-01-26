lines=[]
Goods=5
weight=6
for m in range(0,Goods):
    line=[]
    for n in range(0,weight):
        line.append(0)
    lines.append(line)
ww=[]
vv=[]
ww.append(-1),ww.append(2),ww.append(1),ww.append(3),ww.append(2)
vv.append(-1),vv.append(12),vv.append(10),vv.append(20),vv.append(15)
hh=120
def MFKnapsack(i,j,hh):
    hh=hh+40
    value=0    
    z=int(lines[i][j])
    if z<1 and i>0 and j>0:
        sw=int(ww[i])
        if j<sw:            
            value=MFKnapsack(i-1,j,hh)
        else:
            if MFKnapsack(i-1,j,hh)>int(vv[i])+MFKnapsack(i-1,j-int(ww[i]),hh):
                value=MFKnapsack(i-1,j,hh)                    
            else:
                value=int(vv[i])+MFKnapsack(i-1,j-int(ww[i]),hh)                
        lines[i][j]=value        
    return lines[i][j]        
print("结果：")
print(MFKnapsack(4,5,hh))
print("过程：")
for i in lines:
    print(i)


