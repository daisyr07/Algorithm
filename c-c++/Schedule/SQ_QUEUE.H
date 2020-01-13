const int maxqueue = 1000; //  small value for testing
template<class Queue_entry>
class Queue {
public:
   Queue();
   bool empty() const;
   Error_code serve();
   Error_code append(const Queue_entry &item);
   Error_code retrieve(Queue_entry &item) const;
   Queue(const Queue<Queue_entry> &original);
   void operator =(const Queue<Queue_entry> &original);

protected:
   int count;
   int front, rear;
   Queue_entry entry[maxqueue];
};

template<class Queue_entry>
class Extended_queue: public Queue<Queue_entry> {
public:
   bool full() const;
   int size() const;
   void clear();
   Error_code serve_and_retrieve(Queue_entry &item);
};

template<class Queue_entry>
Queue<Queue_entry>::Queue()
/*
Post: The Queue is initialized to be empty.
*/
{
   count = 0;
   rear = maxqueue - 1;
   front = 0;
}


template<class Queue_entry>
bool Queue<Queue_entry>::empty() const
/*
Post: Return true if the Queue is empty, otherwise return false.
*/
{
   return count == 0;
}


template<class Queue_entry>
Error_code Queue<Queue_entry>::append(const Queue_entry &item)
/*
Post: item is added to the rear of the Queue. If the Queue is full
return an Error_code of overflow and leave the Queue unchanged.
*/

{
   if (count >= maxqueue) return overflow;
   count++;
   rear = ((rear + 1) == maxqueue) ? 0 : (rear + 1);
   entry[rear] = item;
   return success;
}


template<class Queue_entry>
Error_code Queue<Queue_entry>::serve()
/*
Post: The front of the Queue is removed. If the Queue
is empty return an Error_code of underflow.
*/

{
   if (count <= 0) return underflow;
   count--;
   front = ((front + 1) == maxqueue) ? 0 : (front + 1);
   return success;
}


template<class Queue_entry>
Error_code Queue<Queue_entry>::retrieve(Queue_entry &item) const
/*
Post: The front of the Queue retrieved to the output
      parameter item. If the Queue is empty return an Error_code of underflow.
*/

{
   if (count <= 0) return underflow;
   item = entry[front];
   return success;
}


template<class Queue_entry>
Queue<Queue_entry>::Queue(const Queue<Queue_entry> &original)//  copy constructor
/*
Post: The Queue is initialized as a copy of Queue original.
*/
{
	count=original.count;
    front=original.front;
	rear=original.rear;
	for(int i=0;i<maxqueue;i++)
		entry[i]=original.entry[i];
}



template<class Queue_entry>
void Queue<Queue_entry>::operator = (const Queue<Queue_entry> &original) //  Overload assignment
/*
Post: The Queue is reset as a copy of Stack original.
*/
{
	count=original.count;
    front=original.front;
	rear=original.rear;
	for(int i=0;i<maxqueue;i++)
		entry[i]=original.entry[i];
}


template<class Queue_entry>
bool Extended_queue<Queue_entry>::full() const
/*
Post: Return true if the Extended queue is full; return false
otherwise.
*/
{
   return count==maxqueue;
}

template<class Queue_entry>
int Extended_queue<Queue_entry>::size() const
/*
Post:   Return the number of entries in the Extended_queue.
*/
{
   return count;
}

template<class Queue_entry>
void Extended_queue<Queue_entry>::clear()
/*
Post: All entries in the Extended queue have been removed;
it is now empty.
*/
{
   count = 0;
   rear = maxqueue - 1;
   front = 0;
}

template<class Queue_entry>
Error_code Extended_queue<Queue_entry>::serve_and_retrieve(Queue_entry &item)
/*
Return underflow if the Extended queue is empty. Oth-
erwise remove and copy the item at the front of the
Extended queue to item and return success.
*/
{
   if (count == 0) return underflow;
   count--;
   item=entry[front];
   front=(front+1)%maxqueue;
   return true;
}

