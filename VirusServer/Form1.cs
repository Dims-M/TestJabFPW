using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace VirusServer
{
   
    public partial class Form1 : Form
    {
        public Thread refreshThread; // отдельный поток
        public Form1()
        {
            InitializeComponent();
        }

        //при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            refreshThread = new Thread(WaitForConnect);
            refreshThread.Start();// запуск метода в отдельном потоке
        }

        public static void WaitForConnect()
        {

        }

        //после закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshThread.Abort();// завершение потока
        }
    }
}
