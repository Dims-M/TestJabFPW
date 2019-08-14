using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClientCodeBlog
{
    public partial class Form1 : Form
    {
        //Переменные
        const string ip = "192.168.1.78"; // д 192.168.0.45
        const int port = 19132;

        IPEndPoint tcpEndPoint;
        Socket tcpSocket;

        public Form1()
        {
            tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); //Точка подключения с серверу. могуть быть несколько
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // точка подключения между программами.

            InitializeComponent();
        }

        //кнопка выход
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        //Кнопка отправить
        private void Button2_Click(object sender, EventArgs e)
        {

        }

        //При загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Методы

        public void Inicializator()
        {

        }
    }
}
