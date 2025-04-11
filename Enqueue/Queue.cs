using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Enqueue
{
    public class Queue
    {           // реализовано в виде двусвязного сортированного списка
        public bool Empty
        {
            get => (head == null);
        }
        class Node
        {
            public Node next;
            public Node prev;
            int priority;
            int data;

            public int Data
            {
                get => data;
            }
            public int Priority
            {
                get => priority;
            }
            public Node(int data, int priority)
            {
                this.data = data;
                this.priority = priority;
            }
        }
        Node? head = null;
        Node? tail = null;

        public void Enqueue(int data, int priority) // добавление
        {
            if (head == null)
            {
                head = new(data, priority);
                tail = head;
            }

            Node current = head;
            while (current.next != null)
            {
                if (current.Priority <= priority)
                {
                    break;
                }
            }
            if (current.prev == null)
            {
                if (priority <= current.Priority)
                {
                    head = new(data, priority);
                    current.prev = head;
                    return;
                }
            }
            if (current.next == null)
            {
                if (priority > current.Priority)
                {
                    tail = new(data, priority);
                    current.next = tail;
                    return;
                }
            }
            Node res = new(data, priority);
            res.next = current;
            res.prev = current.prev;
            res.prev.next = res;
            current.prev = res;
            return;
        }
        public int Dequeue() // удаление
        {
            if (tail == null)  // по хорошему надо либо вместе со значением возвращать бул успеха либо бросать эксепшион
            {
                Console.WriteLine("Error");
                return 0;
            }

            if (tail.prev == null)
            {
                int res = tail.Data;
                tail = null;
                head = null;
                return res;
            }

            int result = tail.Data;
            tail = tail.prev;
            tail.next = null;
            return result;
        }
    }
}
