using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Serveris
{
    public partial class FORMI : Form
    {
        public FORMI()
        {
            InitializeComponent();
        }

        public void Draw(Rectangle rect)
        {
            System.Drawing.Graphics graphics = CreateGraphics();
            graphics.Clear(FORMI.DefaultBackColor);
            graphics.DrawRectangle(System.Drawing.Pens.Red, rect);
        }

        public static T Deserialize<T>(Stream stm)
        {
            IFormatter fmt = new BinaryFormatter();
            stm.Position = 0;
            T o = (T)fmt.Deserialize(stm);
            stm.Close();
            return o;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            InitializeMe();
        }

        private void InitializeMe()
        {
            Task.Factory.StartNew(() => {
                TcpListener serverSocket = new TcpListener(new System.Net.IPAddress(new byte[] { 127, 0, 0, 1 }), 8888);
                serverSocket.Start();
                Console.WriteLine(" >> Serveris ir palaists");
                while (true)
                {

                    TcpClient cli = serverSocket.AcceptTcpClient();
                    Task.Factory.StartNew(() =>
                    {

                        TcpClient clientSocket = cli;
                        NetworkStream networkStream = clientSocket.GetStream();
                        List<byte> bytesFrom = new List<byte>();
                        MemoryStream memoryStream = new MemoryStream();
                        networkStream.CopyTo(memoryStream);
                        Rectangle s = Deserialize<Rectangle>(memoryStream);
                        Draw(s);

                    });
                }
            });


        }
    }
}
