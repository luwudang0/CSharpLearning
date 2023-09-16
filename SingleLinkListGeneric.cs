using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

class GenericListTest
{
    static void Main()
    {
        GenericList<int> list = new GenericList<int>();

        Console.Write($"Is the list empty? {list.IsEmpty()}\n");
        Console.WriteLine("Add 9-0 to the list: ");
        for (int x = 0; x < 10; x++)
        {
            list.AddHead(x);
        }

        PrintList(list);

        list.AddLast(-1);
        Console.WriteLine("Add -1 to the last:");
        PrintList(list);

        list.AddHead(10);
        Console.WriteLine("Add 10 to the head:");
        PrintList(list);

        list.RemoveHead();
        Console.WriteLine("Remove the head data:");
        PrintList(list);

        list.RemoveLast();
        Console.WriteLine("Remove the last data:");
        PrintList(list);

        list.InsertAtIndex(55, 5);
        Console.WriteLine("Insert 55 at index 5:");
        PrintList(list);

        list.AddHead(0);
        Console.WriteLine("Add 0 to the head:");
        PrintList(list);

        list.AddHead(2);
        Console.WriteLine("Add 2 to the head:");
        PrintList(list);

        list.RemoveValue(0);
        Console.WriteLine("Remove the first 0");
        PrintList(list);

        list.RemoveValueAll(2);
        Console.WriteLine("Remove all 2");
        PrintList(list);

        Console.Write($"Is the list empty? {list.IsEmpty()}");

    }
    private static void PrintList(GenericList<int> list)
    {
        Console.WriteLine($"length: {list.Length}");
        Console.Write("list: ");
        foreach (int i in list)
        {
            Console.Write($"{i} ");
        }
        Console.WriteLine("\n----------------------------------------\n");
    }
}

class GenericList<T> 
{
    private class Node
    {
        private T? data;
        private Node? next;

        public Node(T t)
        {
            data = t;
            next = null;
        }
        public T Data
        {
            get { return data; }
            set { data = value; }
        }
        public Node? Next
        {
            get; set;
        }
    }

    private Node? head;
    private int length;
    public int Length
    {
        get;set;
    }

    public GenericList()
    {
        head = null;
        length = 0;
    }

    public bool IsEmpty()
    {
        return Length == 0;
    }
    public void AddHead(T t)
    {
        Node newNode = new Node(t);
        newNode.Next = head;
        head = newNode;
        Length++;
    }

    public void AddLast(T t)
    {
        Node newNode = new Node(t);
        if(head == null) 
        { 
            head = newNode;
        }
        else
        {
            Node cur = head;
            while(cur.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = newNode;
            Length++;
        }
    }
    public void RemoveHead()
    {
        if(head == null)
        {
            Console.WriteLine("Empty list.");
        }
        else
        {
            head = head.Next;
            Length--;
        }
    }
    public void RemoveLast()
    {
        if (head == null)
        {
            Console.WriteLine("Empty list.");
        }
        else
        {
            Node cur = head;
            while(cur.Next.Next != null)
            {
                cur = cur.Next;
            }
            cur.Next = null;
            Length--;
        }
    }
    public void RemoveValue(T t)
    {
        if(head == null)
        {
            Console.WriteLine("Empty list.");
        }
        else
        {
            if(Length == 1)
            {
               if(head.Data.Equals(t))
                {
                    head = null;
                }
                else
                {
                    head = head.Next;
                }
            }
            else
            {
                Node cur = head;
                Node prev = head;
                while (cur != null)
                {
                    if(cur.Next != null && cur.Next.Data.Equals(t))
                    {
                        prev = cur;
                    }

                    if (cur.Data.Equals(t))
                    {
                        if(cur == head)// if the value to be deleted at head.
                        {
                            head = cur.Next;
                        }
                        else
                        {
                            prev.Next = cur.Next;
                        }
                        Length--;
                        break;
                    }
                    cur = cur.Next;
                }
            }
        }
    }


    public void RemoveValueAll(T t)
    {
        if (head == null)
        {
            Console.WriteLine("Empty list.");
        }
        else
        {
            if (Length == 1)
            {
                if (head.Data.Equals(t))
                {
                    head = null;
                }
                else
                {
                    head = head.Next;
                }
            }
            else
            {
                Node cur = head;
                Node prev = head;
                while (cur != null)
                {
                    if (cur.Next != null && cur.Next.Data.Equals(t))
                    {
                        prev = cur;
                    }

                    if (cur.Data.Equals(t))
                    {
                        if (cur == head)// if the value to be deleted at head.
                        {
                            head = cur.Next;
                        }
                        else
                        {
                            prev.Next = cur.Next;
                        }
                        Length--;
                        //break;  // differ with RemoveValue()
                    }
                    cur = cur.Next;
                }
            }
        }
    }
    public void RemoveAtIndex(int index)
    {
        //todo
    }
    public void InsertAtIndex(T t, int index)
    {
        Node newNode = new Node(t);

        // check the index valid or not.
        if (index < 0 || index > Length - 1)
        {
            throw new IndexOutOfRangeException();
        }

        if(index == 0) 
        { 
            AddHead(t); 
        }
        else
        {   
            if(Length == 1)
            {
                head.Next = newNode;
                Length++;
            }
            else
            {
                Node cur = head;
                Node prev = head;

                while (index != 0)
                {
                    if (index - 1 == 0) { prev = cur; }
                    cur = cur.Next;
                    index--;
                }
                newNode.Next = cur;
                prev.Next = newNode;
                Length++;
            }
        }
    }
    // create an iterator for linklist.
    public IEnumerator<T> GetEnumerator()
    {
        Node? cur = head;
        while (cur != null)
        {
            yield return cur.Data;
            cur = cur.Next;
        }
    }
}