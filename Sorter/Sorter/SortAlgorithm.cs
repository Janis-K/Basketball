using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Windows.Forms;
using System.Drawing.Imaging;
using Gif.Components;
using System.Threading;

namespace SortComparison
{
    public class SortAlgorithm
    {
        ArrayList arrayToSort;
        Graphics g;
        Bitmap bmpsave;
        PictureBox pnlSamples;
        public bool savePicture;
        string outputFolder;
        string outputFile;
        int imgCount;

        int operationsPerFrame; 
        int frameMS; 
        int operationCount;
        Dictionary<int, bool> highlightedIndexes = new Dictionary<int, bool>();
        DateTime nextFrameTime;
        int originalPanelHeight;

        Random rand = new Random();

        public SortAlgorithm(ArrayList list, PictureBox pic)
        {
            imgCount = 0;
            arrayToSort = list;
            pnlSamples = pic;

            operationCount = 0;
            operationsPerFrame = 20;
            frameMS = 1000; 

            while (frameMS >= 40 && operationsPerFrame > 1)
            {
                operationsPerFrame = operationsPerFrame / 2;
                frameMS = frameMS / 2;
            }

            bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
            g = Graphics.FromImage(bmpsave);
            originalPanelHeight = pnlSamples.Height;
            pnlSamples.Image = bmpsave;
            nextFrameTime = DateTime.UtcNow;

            checkForFrame();
        }
        public IList BubbleSort(IList arrayToSort)
        {
            bool swapMade = true;
            int n = arrayToSort.Count - 1;
            for (int i = 0; i < n && swapMade; i++)
            {
                swapMade = false;

                for (int j = n; j > i; j--)
                {
                    if (CompareItems(arrayToSort, j - 1, j) > 0)
                    {
                        SwapItems(arrayToSort, j - 1, j);
                        swapMade = true;
                    }
                }
            }

            return arrayToSort;
        }
        public IList HeapSort(IList list)
        {
            for (int i = (list.Count - 1) / 2; i >= 0; i--)
            {
                AdjustHeap(list, i, list.Count - 1);
            }

            for (int i = list.Count - 1; i >= 1; i--)
            {
                SwapItems(list, 0, i);
                AdjustHeap(list, 0, i - 1);
            }

            return list;
        }
        private void AdjustHeap(IList list, int i, int m)
        {
            object Temp = null;
            SetItem(list, ref Temp, i);

            int j = i * 2 + 1;

            while (j <= m)
            {
                if (j < m)
                {
                    if (CompareItems(list, j, j + 1) < 0)
                    {
                        j = j + 1;
                    }
                }

                if (CompareItems(list, Temp, j) < 0)
                {
                    SetItem(list, i, j);

                    i = j;
                    j = 2 * i + 1;
                }
                else
                {
                    j = m + 1;
                }
            }

            SetItem(list, i, Temp);
        }
        public IList MergeSortInPlace(IList a, int low, int height)
        {
            int l = low;
            int h = height;

            if (l >= h)
            {
                return a;
            }

            int mid = (l + h) / 2;
            MergeSortInPlace(a, l, mid);
            MergeSortInPlace(a, mid + 1, h);

            int end_lo = mid;
            int start_hi = mid + 1;
            while ((l <= end_lo) && (start_hi <= h))
            {
                if (CompareItems(a, l, start_hi) < 0)
                {
                    l++;
                }
                else
                {
                    object temp = null;
                    SetItem(a, ref temp, start_hi);

                    for (int k = start_hi - 1; k >= l; k--)
                    {
                        SetItem(a, k + 1, k);
                    }
                    SetItem(a, l, temp);

                    l++;
                    end_lo++;
                    start_hi++;
                }
            }

            return a;
        }
        public IList Quicksort(IList a, int left, int right)
        {
            int i = left;
            int j = right;

            object x = null;
            SetItem(a, ref x, rand.Next(left, right + 1));

            // find items to swap so smaller items are on the left side and larger items are on the right side
            while (i <= j) // when i=j, need to compare to know which way to move (left or right)
            {
                while (CompareItems(a, i, x) < 0)
                {
                    i++;
                }
                while (CompareItems(a, x, j) < 0)
                {
                    j--;
                }

                if (i < j)
                {
                    SwapItems(a, i, j);
                    i++;
                    j--;
                }
                else if (i == j) // no need to swap in this case
                {
                    i++;
                    j--;
                }
            }

            // now everything from left to j is less than or equal to the pivot
            // and everything from i to right is greater than or equal to the pivot
            // note that we don't need to push the pivot in between these partitions to be fast
            if (left < j)
            {
                Quicksort(a, left, j);
            }
            if (i < right)
            {
                Quicksort(a, i, right);
            }

            return a;
        }
        private void SetItem(IList arrayToSort, int toIndex, int fromIndex)
        {
            arrayToSort[toIndex] = arrayToSort[fromIndex];

            if (!highlightedIndexes.ContainsKey(toIndex))
                highlightedIndexes.Add(toIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SetItem(IList arrayToSort, int toIndex, object fromObject)
        {
            arrayToSort[toIndex] = fromObject;

            if (!highlightedIndexes.ContainsKey(toIndex))
                highlightedIndexes.Add(toIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SetItem(IList arrayToSort, ref object toObject, int fromIndex)
        {
            toObject = arrayToSort[fromIndex];

            if (!highlightedIndexes.ContainsKey(fromIndex))
                highlightedIndexes.Add(fromIndex, false);

            operationCount++;
            checkForFrame();
        }
        private void SwapItems(IList arrayToSort, int index1, int index2)
        {
            object temp = arrayToSort[index1];
            arrayToSort[index1] = arrayToSort[index2];
            arrayToSort[index2] = temp;

            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount += 2;
            checkForFrame();
        }
        private int CompareItems(IList arrayToSort, int index1, int index2)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);
            if (!highlightedIndexes.ContainsKey(index2))
                highlightedIndexes.Add(index2, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(arrayToSort[index2]);
        }
        private int CompareItems(IList arrayToSort, int index1, object o)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)arrayToSort[index1]).CompareTo(o);
        }
        private int CompareItems(IList arrayToSort, object o, int index1)
        {
            if (!highlightedIndexes.ContainsKey(index1))
                highlightedIndexes.Add(index1, false);

            operationCount++;
            checkForFrame();

            return ((IComparable)o).CompareTo(arrayToSort[index1]);
        }

        private void checkForFrame()
        {
            if (operationCount >= operationsPerFrame || nextFrameTime <= DateTime.UtcNow)
            {
                // time to draw a new frame and wait
                DrawSamples();
                RefreshPanel(pnlSamples);

                // prepare for next frame
                highlightedIndexes.Clear();
                operationCount -= operationsPerFrame; // if there were more operations than needed, don't just forget those

                if (DateTime.UtcNow < nextFrameTime)
                {
                    Thread.Sleep((int)((nextFrameTime - DateTime.UtcNow).TotalMilliseconds));
                }
                nextFrameTime = nextFrameTime.AddMilliseconds(frameMS);
            }
        }

        public void finishDrawing()
        {
            if (highlightedIndexes.Count > 0)
            {
                // put one last frame in before the end
                nextFrameTime = DateTime.UtcNow;
                checkForFrame();
            }

            // draw the last frame
            nextFrameTime = DateTime.UtcNow;
            checkForFrame();
        }

        private ImageCodecInfo getEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] codecs = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < codecs.Length; i++)
                if (codecs[i].MimeType == mimeType)
                    return codecs[i];
            return null;
        }

        delegate void SetControlValueCallback(Control pnlSort);

        private void RefreshPanel(Control pnlSort)
        {
            if (pnlSort.InvokeRequired)
            {
                SetControlValueCallback d = new SetControlValueCallback(RefreshPanel);
                pnlSort.Invoke(d, new object[] { pnlSort });
            }
            else
            {
                pnlSort.Refresh();
            }
        }

        public void DrawSamples()
        {
            // might need to grow or shrink if size is different from original (can't change array!)
            double multiplyHeight = 1;

            // check if need to change size
            if (bmpsave.Width != pnlSamples.Width || bmpsave.Height != pnlSamples.Height)
            {
                bmpsave = new Bitmap(pnlSamples.Width, pnlSamples.Height);
                g = Graphics.FromImage(bmpsave);
                pnlSamples.Image = bmpsave;
            }

            if (pnlSamples.Height != originalPanelHeight)
            {
                multiplyHeight = (double)(pnlSamples.Height) / (double)(originalPanelHeight);
            }

            // start with white background
            g.Clear(Color.White);

            // use black sometimes
            Pen pen = new Pen(Color.Black);
            SolidBrush b = new SolidBrush(Color.Black);

            // use red sometimes
            Pen redPen = new Pen(Color.Red);
            SolidBrush redBrush = new SolidBrush(Color.Red);

            // draw a nice width based on number of elements
            int w = (pnlSamples.Width / arrayToSort.Count) - 1;

            for (int i = 0; i < this.arrayToSort.Count; i++)
            {
                int x = (int)(((double)pnlSamples.Width / arrayToSort.Count) * i);

                int itemHeight = (int)Math.Round(Convert.ToDouble(arrayToSort[i]) * multiplyHeight);

                // draw highlighed versions
                if (highlightedIndexes.ContainsKey(i))
                {
                    if (w <= 1)
                    {
                        g.DrawLine(redPen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(redBrush, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
                else // draw normal versions
                {
                    if (w <= 1)
                    {
                        g.DrawLine(pen, new Point(x, pnlSamples.Height), new Point(x, (int)(pnlSamples.Height - itemHeight)));
                    }
                    else
                    {
                        g.FillRectangle(b, x, pnlSamples.Height - itemHeight, w, pnlSamples.Height);
                    }
                }
            }
        }
    }
}
