using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;

namespace SortComparison
{
    public partial class frmMain : Form
    {
        ArrayList array1;
        ArrayList array2;
        ArrayList array3;
        ArrayList array4;
        Bitmap bmpsave1;
        Bitmap bmpsave2;
        Bitmap bmpsave3;
        Bitmap bmpsave4;

        static Random rand = new Random();

        Thread thread1;
        Thread thread2;
        Thread thread3;
        Thread thread4;

        public frmMain()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        public void Randomize(IList list)
        {
            for (int i = list.Count - 1; i > 0; i--)
            {
                int swapIndex = rand.Next(i + 1);
                if (swapIndex != i)
                {
                    object tmp = list[swapIndex];
                    list[swapIndex] = list[i];
                    list[i] = tmp;
                }
            }
        }

        private void PrepareForSort()
        {
            bmpsave1 = new Bitmap(pnlSort1.Width, pnlSort1.Height);

            bmpsave2 = new Bitmap(pnlSort2.Width, pnlSort2.Height);

            bmpsave3 = new Bitmap(pnlSort3.Width, pnlSort3.Height);

            bmpsave4 = new Bitmap(pnlSort4.Width, pnlSort4.Height);

            pnlSort1.Image = bmpsave1;
            pnlSort2.Image = bmpsave2;
            pnlSort3.Image = bmpsave3;
            pnlSort4.Image = bmpsave4;

            array1 = new ArrayList(100);
            array2 = new ArrayList(100);
            array3 = new ArrayList(100);
            array4 = new ArrayList(100);
            for (int i = 0; i < array1.Capacity; i++)
            {
                int y = (int)((double)(i + 1) / array1.Capacity * pnlSort1.Height);
                array1.Add(y);
            }
            Randomize(array1);

            array2 = (ArrayList)array1.Clone();
            array3 = (ArrayList)array1.Clone();
            array4 = (ArrayList)array1.Clone();
        }

        private void cmdSort_Click(object sender, EventArgs e)
        {
            if (thread1 != null)
            {
                thread1.Abort();
                thread1.Join();
            }
            if (thread2 != null)
            {
                thread2.Abort();
                thread2.Join();
            }
            if (thread3 != null)
            {
                thread3.Abort();
                thread3.Join();
            }
            if (thread4 != null)
            {
                thread4.Abort();
                thread4.Join();
            }

            PrepareForSort();

            SortAlgorithm sa = new SortAlgorithm(array1, pnlSort1);
            SortAlgorithm sa2 = new SortAlgorithm(array2, pnlSort2);
            SortAlgorithm sa3 = new SortAlgorithm(array3, pnlSort3);
            SortAlgorithm sa4 = new SortAlgorithm(array4, pnlSort4);

            ThreadStart ts = delegate ()
            {
                sa.BubbleSort(array1);
                sa.finishDrawing();
            };

            ThreadStart ts2 = delegate ()
            {
                sa2.Quicksort(array2, 0, array2.Count - 1);
                sa2.finishDrawing();
            };

            ThreadStart ts3 = delegate ()
            {
                sa3.HeapSort(array3);
            };

            ThreadStart ts4 = delegate ()
            {
                sa4.MergeSortInPlace(array4, 0, array4.Count - 1);
            };

            thread1 = new Thread(ts);
            thread1.Start();

            thread2 = new Thread(ts2);
            thread2.Start();

            thread3 = new Thread(ts3);
            thread3.Start();

            thread4 = new Thread(ts4);
            thread4.Start();

        }

        private bool isSorted(IList checkThis)
        {
            for (int i = 0; i < checkThis.Count - 1; i++)
            {
                if (((IComparable)checkThis[i]).CompareTo(checkThis[i + 1]) > 0)
                    return false;
            }

            return true;
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
