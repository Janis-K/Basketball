using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sorting
{
    public partial class Form1 : Form
    {

        List<int> list;
        public Form1()
        {
            InitializeComponent();
        }

        private void sort_Click(object sender, EventArgs e)
        {
            Thread quick = new Thread(InvokeQuickSort);
            quick.Start();
            Thread bubble = new Thread(InvokeBubbleSort);
            bubble.Start();
        }

        private void generate_Click(object sender, EventArgs e)
        {
            Random r = new Random();
            list = new List<int>();
            for (int i = 0; i < 300; i++)
            {
                list.Add(r.Next(100));
            }
            quickSort.Text = DisplayList(list);
            bubbleSort.Text = DisplayList(list);
            mergeSort.Text = DisplayList(list);
            heapSort.Text = DisplayList(list);
        }
        public string DisplayList(List<int> list)
        {
            return string.Join(",", list.ToArray());
        }
        public void InvokeQuickSort()
        {
            Action act = delegate () {
                quickSort.Enabled = true;
                QuickSort(list); };
            quickSort.Invoke(act);
        }

        public void InvokeBubbleSort()
        {
            Action act = delegate () {
                var newList = BubbleSort(list);
                bubbleSort.Text = DisplayList(newList);
            };
        }
        public List<int> QuickSort(List<int> mylist)
        {
            Random r = new Random();
            List<int> less = new List<int>();
            List<int> greater = new List<int>();

            if (mylist.Count <= 1)
                return mylist;

            int pos = r.Next(mylist.Count);

            int pivot = mylist[pos];
            mylist.RemoveAt(pos);


            foreach (int x in mylist)
            {
                if (x <= pivot)
                {
                    less.Add(x);
                }
                else
                {
                    greater.Add(x);
                }

            }

            return concat(QuickSort(less), pivot, QuickSort(greater));
        }

        public List<int> concat(List<int> less, int pivot, List<int> greater)
        {
            List<int> sorted = new List<int>(less);

            sorted.Add(pivot);

            foreach (int i in greater)
            {
                sorted.Add(i);
                quickSort.Text = DisplayList(sorted);
                quickSort.GetBindingExpression(TextBox.TextProperty).UpdateTarget();
                Thread.Sleep(1000);
            }


            return sorted;
        }

        public List<int> BubbleSort(List<int> myList)
        {
            int temp;

            for (int i = 1; i <= myList.Count; i++)
            {
                for (int j = 0; j < myList.Count - i; j++)
                {
                    if (myList[j] > myList[j + 1])
                    {
                        temp = myList[j];
                        myList[j] = myList[j + 1];
                        myList[j + 1] = temp;
                        bubbleSort.Text = DisplayList(myList);
                    }
                }
            }
            bubbleSort.Text = DisplayList(myList);
            return myList;
        }
    }
}
