using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lab08_a
{
    public interface IMyList<T>
    {
        void Add(T elem);
        T Get(int index);
        T RemoveLast(); 
        int Size { get; } 
    }
    public abstract class GenericList<T>:IMyList<T>,IEnumerable<T> // dodać odpowiednie interfejsy
    {
        protected Node head;
        protected class Node
        {
            public Node(T t)
            {
                Next = null;
                Data = t;
            }
            public Node Next { get; set; }
            public T Data { get; set; }
        }
        public GenericList()
        {
            head = null;

        }
        public abstract void Add(T elem);

        public T Get(int index)
        {
            if (Size == 0) throw new Exception("List is empty");
            Node cur = head;
            for(int i=0;i<index&&cur!=null;i++)
            {
                cur = cur.Next;
            }
            
            if (cur == null) return default(T);
            return cur.Data;
            
        }
        public T RemoveLast()
        {
            if(Size==0) throw new Exception("List is empty");
            Node cur = head;
            Node prev = head;
           
            while(cur.Next!=null)
            {
                prev = cur;
                cur = cur.Next;
            }
            if(cur==head)
            {
                head = null;
                return cur.Data;
            }
            prev.Next = null;
            return cur.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node cur = head;
            for(int i=0;i<Size;i++)
            {
                yield return cur.Data;
                cur = cur.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public int Size
        {
            get
            {
                Node cur = head;
                int i = 0;
                while(cur!=null)
                {
                    i++;
                    cur = cur.Next;
                }
                return i;
            }
        }
        

    }
    public class MyList<T> : GenericList<T>
    {
        public override void Add(T elem)
        {
            Node wstaw = new Node(elem);
            Node glowa = head;
            head = wstaw;
            head.Next = glowa;

        }
        public override string ToString()
        {
            string a="";
            Node cur = head;
            
            while (cur != null)
            {
                if (cur.Next != null)
                    a += cur.Data.ToString() + " --> ";
                else
                    a += cur.Data.ToString();

                cur = cur.Next;
            }
            return a;
        }
    }
    public class SortedMyList<T> : GenericList<T>
    where T: IComparable<T>
    {
        public override void Add(T elem)
        {
            
            Node wstaw = new Node(elem);
            Node cur = head;
            Node prev = head;
            

            if (head==null)
            {
                head = wstaw;
                return;
            }
           

            while (cur!=null&&cur.Data.CompareTo(elem)<=0)
            {
                prev = cur;
                cur = cur.Next;
            }
            

            if (cur==head)
            {

                wstaw.Next = head;
                 head = wstaw;
                return;
             

            }
            

            if (cur!=null)
            {
                wstaw.Next = prev.Next;
                prev.Next = wstaw;
            }
            

            else
            {
                prev.Next = wstaw;
            }
        }
        public override string ToString()
        {
            string a = "";
            Node cur = head;

            while (cur != null)
            {
                if (cur.Next != null)
                    a += cur.Data.ToString() + " --> ";
                else
                    a += cur.Data.ToString();

                cur = cur.Next;
            }
            return a;
        }
    }
    public class Person:IComparable<Person>
    {
        public int Age { get; set; }
        public string Name { get; set; }

       

        public int CompareTo(Person other)
        {
            if (Name.CompareTo(other.Name) > 0) return 1;
            if (Name.CompareTo(other.Name) < 0) return -1;
            if (Age < other.Age) return -1;
            if (Age < other.Age) return 1;
            return 0;


        }

        public override string ToString()
        {
            string a = Name + ", " + Age;
            return a;
        }


    }

}
