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

namespace FormThread
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public void Move1()
        {
            while (button1.Bottom < this.ClientSize.Height)
            {
                
                Thread.Sleep(10);
                Action act = delegate () { button1.Top++; };
                button1.Invoke(act);


            }
        }

        public void Move2()
        {
            while (button2.Bottom < this.ClientSize.Height)
            {
                Thread.Sleep(10);
                Action act = delegate () { button2.Top++; };
                button2.Invoke(act);
            }
        }

        public void Move3()
        {
            while (button3.Bottom < this.ClientSize.Height)
            {
                Thread.Sleep(10);
                Action act = delegate () { button3.Top++; };
                button3.Invoke(act);
            }
        }

        private void Form1_MouseClick(object sender, MouseEventArgs e)
        {
            var t1 = new Thread(Move1);
            t1.Priority = ThreadPriority.Highest;
            t1.Start();
            var t2 = new Thread(Move2);
            t2.Priority = ThreadPriority.Lowest;
            t2.Start();
            var t3 = new Thread(Move3);
            t3.Priority = ThreadPriority.Lowest;
            t3.Start();
        }
    }
}
