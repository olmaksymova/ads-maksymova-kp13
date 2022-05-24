using System;
using static System.Console;

namespace lab6
{
    public class Node
    {
        public char data;
        public Node next;
        public Node prev;
        public Node(char data)
        {
            this.data = data;
            this.prev = null;
            this.next = null;
        }
    }
    public class Deque
    {
        private Node Head;
        private Node Tail;
        private int Size;
        public Deque()
        {
            Head = null;
            Tail = null;
            Size = 0;
        }
        public bool isEmpty()
        {
            if (this.Head == null)
                return true;
            else
                return false;
        }
        public void insertHead(char buffer)
        {
            Node node = new Node(buffer);
            node.next = this.Head;
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                this.Head.prev = node;
                this.Head = node;
            }
            this.Size++;
            this.printDeque();
        }
        public Deque Copy()
        {
            Deque clone = new Deque();
                Node node = this.Head;
                while (node != null)
                {
                    clone.insertTail(node.data);
                    node = node.next;
                }
                return clone;
        }
        public void insertTail(char buffer)
        {
            Node node = new Node(buffer);
            if (this.Head == null)
            {
                this.Head = node;
                this.Tail = node;
            }
            else
            {
                node.prev = this.Tail;
                this.Tail.next = node;
                this.Tail = node;
            }
            this.Size++;
            this.printDeque();
        }
        public void removeTail()
        {
            if (this.isEmpty() == true)
            {
                return;
            }
            this.Tail = this.Tail.prev;

            if (this.Tail == null)
            {
                this.Head = null;
            }
            else
            {
                this.Tail.next = null;
            }
            this.Size--;

            this.printDeque();
        }
        public void removeHead()
        {
            if (this.isEmpty() == true)
            {
                return;
            }
            this.Head = this.Head.next;
            if (this.Head == null)
            {
                this.Tail = null;
            }
            else
            {
                this.Head.prev = null;
            }
            this.Size--;
            this.printDeque();
        }

        public Node head() => this.Head;

        public Node tail() => this.Tail;
        public int size() => this.Size;
        public void printDeque()
        {
            Node node = this.Head;
            if (node != null)
            {
                WriteLine("\nДана черга");
                while (node != null)
                {
                    Write(node.data);
                    node = node.next;
                }
            }
            else
                WriteLine("\nДана черга порожня!");
            ResetColor();
            WriteLine();
        }
        public bool isPalindrome()
        {
            WriteLine("\n************************Створення копiї черги************************");
            Deque current = this.Copy();

            if (!current.isEmpty())
            {
                WriteLine("\n************************Видалення елементiв з копiї************************");
                do
                {
                    if (current.Head.data == current.Tail.data)
                    {
                        current.removeTail();
                        current.removeHead();
                    }
                    else
                        return false;
                }
                while (!current.isEmpty());
                return true;
            }
            else return false;
        }
        public void printHalfDeque()
        {
            string half = "";
            WriteLine("\n************************Створення копiї черги************************");
            Deque current = this.Copy();

            WriteLine("\n************************Видалення елементiв з копiї************************");
            while (!current.isEmpty())
            {
                half += current.Tail.data;

                current.removeHead();
                current.removeTail();
            }
            Program.ColorWriteLine($"Половина даної черги\n{half}");
        }
        public void printTransposition()
        {
            WriteLine("\n************************Перестановка правої половини деку на його початок************************");
            for (int i = 0; i < this.Size/2f; i++)
            {
                this.insertHead(this.Tail.data);
                this.removeTail();
            }

            ForegroundColor = ConsoleColor.DarkRed;
            BackgroundColor = ConsoleColor.White;
            this.printDeque();
            ResetColor();
        }
    }
}
