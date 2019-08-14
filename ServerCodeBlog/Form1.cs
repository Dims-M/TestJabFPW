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

namespace ServerCodeBlog
{
    //https://www.youtube.com/watch?v=ZRGgBtUgJKE&t=1518s
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

        //Кнопка выход
        private void Button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        //При загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        //Методы

        /// <summary>
        /// Инициализатор поле и переменных
        /// </summary>
        public void InisalizaorFild()
        {   // режим ожидания
            tcpSocket.Bind(tcpEndPoint); // Связка точки доступа и сокета
            tcpSocket.Listen(5); // запус состояния прошлушивания

            while (true)
            {
                var listener = tcpSocket.Accept(); // прошлушка сокета и при подключении создание нового скета для ответа
                var buffer = new byte[256]; // массив буфера
                var size = 0;
                var data = new StringBuilder();

                do // проверяем условие о получили запрос
                {
                    size = listener.Receive(buffer); // полученно все байти сообщения. Маскимальное  
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size)); // добавляем полученые через сокет  раскадированное данные из бкфера
                }
                while (listener.Available > 0); // если полученные данные еще есть. цикл работает
               


            }
        }
    }
}
