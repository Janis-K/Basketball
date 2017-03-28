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

namespace Serveris
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new FORMI());
        }

        public static T Deserialize<T>(Stream stm)
        {
            IFormatter fmt = new BinaryFormatter();
            stm.Position = 0;
            T o = (T)fmt.Deserialize(stm);
            stm.Close();
            return o;
        }

    }
}
