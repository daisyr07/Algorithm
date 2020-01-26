import random
seed='ABCD'
f=open('dna1.txt','w')
for j in range(2000):
    s=''
    for i in range(20):
        s+=random.choice(seed)
    f.write('S'+str(j).zfill(5)+'\t'+s+'\n')
f.flush()
f.close()

f=open('dna1.txt','r')
dict={}

#相似度匹配的例序列
sample='S00004  ADDABDADDBDABCAAABAB'
for i in f:
    i=i.replace('\n','')
    dict[i]=0
print(dict.items())
f.close()

for i in dict.keys():
    con=0
    for j in range(20):
        if i[-20:][j]==sample[-20:][j]:
            con+=1
    dict[i]=con

list1=sorted(dict.items(), key=lambda  x:x[1],reverse=True)
print(list1)

f=open('result.txt','w')
for i in list1:
    f.write(str(i)+'\n')

f.close()
