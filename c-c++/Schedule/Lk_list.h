template <class Node_entry>
struct Node {
//  data members
   Node_entry entry;
   Node<Node_entry> *next;
//  constructors
   Node();
   Node(Node_entry, Node<Node_entry> *link = NULL);
};


template<class Node_entry>
Node<Node_entry>::Node()
{
   next = NULL;
}


template<class Node_entry>
Node<Node_entry>::Node(Node_entry item, Node<Node_entry> *link)
{
   entry = item;
   next = link;
}


template <class List_entry>
class List {
public:
//  Add specifications for the methods of the list ADT.
//  Add methods to replace the compiler-generated defaults.
   List();
   ~List();
   int size() const;
   bool empty() const;
   void clear();
   void traverse(void (*visit)(List_entry &));
   Error_code retrieve(int position, List_entry &x) const;
   Error_code replace(int position, const List_entry &x);
   Error_code remove(int position, List_entry &x);
   Error_code insert(int position, const List_entry &x);
   List(const List<List_entry> &copy);
   void operator =(const List<List_entry> &copy);

protected:
//  Data members for the linked-list implementation with
//  current position follow:
   int count;
   mutable int current_position;
   Node<List_entry> *head;
   mutable Node<List_entry> *current;

//  Auxiliary function to locate list positions follows:
   void set_position(int position) const;
};


template <class List_entry>
List<List_entry>::List()
{
	count=0;
	head=NULL;
	current_position=-1;
	current=NULL;
}


template <class List_entry>
bool List<List_entry>::empty() const
{
   return count==0;
}


template <class List_entry>
List<List_entry>::~List()
{
	clear();
}


template <class List_entry>
int List<List_entry>::size() const
/*
Post: The function returns the number of entries in the List.
*/
{
	return count;
}


template <class List_entry>
void List<List_entry>::clear()
{
	List_entry x;
	while(size()>0)remove(0,x);
}


template <class List_entry>
void List<List_entry>::traverse(void (*visit)(List_entry &))
/*
Post: The action specified by function (*visit) has been performed on every
      entry of the List, beginning at position 0 and doing each in turn.
*/
{
	List_entry x;
	for (int i = 0; i < count; i++){
		retrieve(i,x);
        (*visit)(x);
	}
}


template <class List_entry>
Error_code List<List_entry>::retrieve(int position, List_entry &x) const
{
    if (position < 0 || position > count-1)
		return range_error;
	set_position(position);
	x = current->entry;
    return success;
}


template <class List_entry>
Error_code List<List_entry>::replace(int position, const List_entry &x)
{
    if (position < 0 || position > count-1)
		return range_error;
	set_position(position);
	current->entry=x;
    return success;
}


template <class List_entry>
Error_code List<List_entry>::remove(int position, List_entry &x)
{
   if (position < 0 || position > count-1)
      return range_error;
   Node<List_entry> *previous, *following;
   if(position==0){
	   following=head;
	   head=head->next;
	   current=head;
	   if(head==NULL)current_position=-1;
	   else current_position=0;
   } 
   else{
	   set_position(position - 1);
	   previous = current;
	   following = previous->next;
	   previous->next = following->next;
   }
   x=following->entry;
   delete following;
   count--;
   return success;
}


template <class List_entry>
Error_code List<List_entry>::insert(int position, const List_entry &x)
/*
Post: If the List is not full and 0 <= position <= n,
      where n is the number of entries in the List, the function succeeds:
      Any entry formerly at position and all later entries have their position
      numbers increased by 1, and x is inserted at position of the List.
      Else: The function fails with a diagnostic error code.
*/
{
   if (position < 0 || position > count)
      return range_error;
   Node<List_entry> *new_node, *previous, *following;
   if (position > 0) {
       set_position(position - 1);
	   previous = current;
       following = previous->next;
   }
   else 
	   following = head;
   new_node = new Node<List_entry>(x, following);
   if (new_node == NULL)
      return overflow;
   if(position == 0) head = new_node;
   else previous->next = new_node;
   current=new_node;
   current_position=position;
   count++;
   return success;
}


template <class List_entry>
List<List_entry>::List(const List<List_entry> &copy)
{
   count=copy.count;
   Node<List_entry> *new_copy, *original_node = copy.head;
   if (count == 0) {
	  head = NULL;
   }
   else {                         
	  current_position=0;
	  //  Duplicate the linked nodes.
      current = head = new_copy = new Node<List_entry>(original_node->entry);
      while (original_node->next != NULL) {
		  original_node = original_node->next;
	      new_copy->next = new Node<List_entry>(original_node->entry);
	      new_copy = new_copy->next;
      }
      set_position(copy.current_position); 
   }
}


template <class List_entry>
void List<List_entry>::operator =(const List<List_entry> &copy)
{
   clear();
   count=copy.count;
   Node<List_entry> *new_copy, *original_node = copy.head;
   if (count == 0) {
	  head = NULL;
   }
   else {                    
	  current_position=0;
	  //  Duplicate the linked nodes.
      current = head = new_copy = new Node<List_entry>(original_node->entry);
      while (original_node->next != NULL) {
		  original_node = original_node->next;
	      new_copy->next = new Node<List_entry>(original_node->entry);
	      new_copy = new_copy->next;
      }
	  current=head;
      set_position(copy.current_position); 
   }
}


template <class List_entry>
void List<List_entry>::set_position(int position) const
/*
Pre:  position is a valid position in the List: 0 <= position < count.
Post: The current Node pointer references the Node at position.
*/
{
   if (position < current_position) {  //  must start over at head of list
      current_position = 0;
      current = head;
   }
   for ( ; current_position != position; current_position++)
      current = current->next;
}


