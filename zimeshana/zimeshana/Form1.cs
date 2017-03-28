using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace zimeshana
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Graphics formGraphics;
        bool isDown = false;
        int initialX;
        int initialY;
        Rectangle rect;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            isDown = true;
            initialX = e.X;
            initialY = e.Y;
        }

        private void Form1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isDown == true)
            {
                this.Refresh();
                Pen drwaPen = new Pen(Color.Navy, 1);
                int width = e.X - initialX, height = e.Y - initialY;
                rect = new Rectangle(initialX, initialY, width * Math.Sign(width), height * Math.Sign(height));

                formGraphics = this.CreateGraphics();
                formGraphics.DrawRectangle(drwaPen, rect);
                TcpClient cli = new TcpClient("127.0.0.1", 8888);
                Stream stm = cli.GetStream();
                Serialize<Rectangle>(stm, rect);
                cli.Close();
            }
        }
        private void Form1_MouseUp(object sender, MouseEventArgs e)
        {
            isDown = false;
            TcpClient cli = new TcpClient("127.0.0.1", 8888);
            Stream stm = cli.GetStream();
            Serialize<Rectangle>(stm, rect);
            cli.Close();
        }

        public void Serialize<T>(Stream stm, T root)
        {
            IFormatter fmt = new BinaryFormatter();
            fmt.Serialize(stm, root);
            stm.Flush();
            stm.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }
    }
}
