goods=[[1,2,12],[2,1,10],[3,3,20],[4,2,15]]
def partition(g,l,r):
    vstart=g[l][2]/g[l][1]
    i=l
    j=r
    while i<j:
        if g[i][2]/g[i][1]>g[j][2]/g[j][1]:
            temp=g[i]
            g[i]=g[j]
            g[j]=temp
        if g[i][2]/g[i][1]==vstart:
            j-=1
        else:
            i+=1
    return i+l
def QuickSort(l,r,g):
    if l<r:
        s=partition(g,l,r)
        QuickSort(l,s-1,g)
        QuickSort(s+1,r,g)
QuickSort(0,len(goods)-1,goods)
print('单位价值排序：',goods)
bagW=5
def addbag(g,w):
    w1=w
    bag=[]
    v=0
    j=0
    i=len(g)-1
    while i>=0:
        if g[i][1]<=w1:
            bag.append(g[i])
            w1-=g[i][1]
            v+=g[i][2]
        i-=1
    print('总价值：',v)
addbag(goods,bagW)


