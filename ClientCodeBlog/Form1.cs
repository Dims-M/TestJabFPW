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

        string log = "Журнал событий \t\n";

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
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(() => InicializatorClienta());
        }

        //Методы
        public void InicializatorClienta()
        {
            string dateTime = DateTime.Now.ToString();
            string message = $"{dateTime}\t\nСообщение:{textBox1.Text}"; //  тело сообщенияя

            var data = Encoding.UTF8.GetBytes(message); // кодировка сообщение в байты. переод отправкой серверу

            //подключение(открытие) сокета/ Через точку доступа tcpEndPoint. Подключаемся как клиент в режиме слушателя
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data); //отправка сообщения


        }
    }
}
