using System;
using System.Windows.Forms;

namespace Варіант6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public class SLList
        {
            public Node head;
            public class Node
            {
                public string data;
                public Node next;
                public Node(string data)
                {
                    this.data = data;
                }
                public Node(string data, Node next)
                {
                    this.data = data;
                    this.next = next;
                }
            }
            public SLList(string data)
            {
                head = new Node(data);
            }
            public SLList()
            {
                head = null;
            }

            public void AddFirst(string data)
            {
                Node current = head;
                head = new Node(data);
                head.next = current;
            }
            public void AddToPosition(string data, int position)
            {
                Node current = head;
                int i = 1;

                while (i != position - 1 && current.next != null)
                {
                    current = current.next;
                    i++;
                }

                current.next = new Node(data, current.next);
            }
            public int Count()
            {
                Node current = head;

                int count = 1;

                while (current.next != null)
                {
                    count++;
                    current = current.next;
                }

                return count;
            }
            public void AddLast(string data)
            {
                Node current = head;

                while (current.next != null)
                {
                    current = current.next;
                }

                current.next = new Node(data, null);
            }


            public void DeleteFirst()
            {
                Node current = head;
                head = head.next;
                current = null;
            }

            public void DeleteLast()
            {
                Node current = head;

                while (current.next.next != null)
                {
                    current = current.next;
                }

                current.next = null;

            }
            public void DeleteFromPosition(int position)
            {
                Node current = head;
                int i = 1;

                while (i != position - 1 && current.next != null)
                {
                    current = current.next;
                    i++;
                }

                Node temp = current.next.next;
                current.next = null;
                current.next = temp;

            }
            public void Print(TextBox t)
            {

                Node current = head;

                while (current.next != null)
                {
                    t.Text += current.data + " ";
                    current = current.next;
                }

                t.Text += current.data + " ";
            }
        }



        private void button1_Click(object sender, EventArgs e)
        {
            textBox2.Text = "";

            textBox1.Text += "";
            string[] Data = textBox1.Text.Split(' ');
            SLList list = new SLList();

            if (Data[0] != null)
                list = new SLList(Data[0]);
            try
            {
                for (int i = 1; i < Data.Length; i++)
                    list.AddLast(Data[i]);

                string newelement = textBox7.Text;

                if (radioButton1.Checked)
                    list.DeleteFirst();

                else if (radioButton2.Checked)
                    list.DeleteLast();

                else if (radioButton3.Checked)
                {
                    if (Convert.ToInt32(textBox3.Text) != 1)
                        list.DeleteFromPosition(Convert.ToInt32(textBox3.Text));
                    else
                        list.DeleteFirst();
                }

                else if (radioButton4.Checked)
                {
                    if (Convert.ToInt32(textBox5.Text) != 1)
                        list.AddToPosition(textBox4.Text, Convert.ToInt32(textBox5.Text));
                    else
                        list.AddFirst(textBox4.Text);
                }

                else if (radioButton5.Checked)
                    list.AddFirst(textBox6.Text);

                //Безпосереднє завдання
                else if (radioButton6.Checked)
                {
                    if (list.Count() % 2 == 1)
                        list.AddToPosition(newelement, list.Count() / 2 + 1);
                    else
                        MessageBox.Show("Введіть непарну кількість елементів!");
                }

                else if (radioButton7.Checked)
                    list.AddLast(textBox8.Text);
                list.Print(textBox2);
            }

            catch
            {
                MessageBox.Show("Помилка введення даних!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
