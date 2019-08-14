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
        const string ip = "192.168.1.54"; // д 192.168.0.45 192.168.1.54
        const int port = 19132;
        string message="";

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
            tcpSocket.Shutdown(SocketShutdown.Both); //двухстроние закрытие соединение. на снервере и на клиенте
            tcpSocket.Close();
            Close();
        }

        //Кнопка отправить
        private void Button2_Click(object sender, EventArgs e)
        {
            string dateTime = DateTime.Now.ToString();
             message += $"{dateTime}\t\nСообщение от клиента: {textBox1.Text}"; //  тело сообщенияя
            // await Task.Run(() => InicializatorClienta());
            InicializatorClienta();
            // message += textBox1.Text;
            // Invoke((MethodInvoker)delegate { label1.Text = log; ; }); //вывод в лабел минуя ошибку
        }

        //При загрузке формы
        private async void Form1_Load(object sender, EventArgs e)
        {
          //  await Task.Run(() => InicializatorClienta());
        }

        //Методы
        public void InicializatorClienta()
        {
            
           // string message = $"{dateTime}\t\nСообщение:{textBox1.Text}"; //  тело сообщенияя

            var data = Encoding.UTF8.GetBytes(message); // кодировка сообщение в байты. переод отправкой серверу

            //подключение(открытие) сокета/ Через точку доступа tcpEndPoint. Подключаемся как клиент в режиме слушателя
            tcpSocket.Connect(tcpEndPoint);
            tcpSocket.Send(data); //отправка сообщения

            var buffer = new byte[256]; // массив буфера
            var size = 0;
            var answer = new StringBuilder(); //

            do // проверяем условие о получили запрос
            {
                size = tcpSocket.Receive(buffer); // полученно все байти сообщения. Маскимальное  
                answer.Append(Encoding.UTF8.GetString(buffer, 0, size)); // добавляем полученые через сокет  раскадированное данные из бкфера
                log += "Полeчены данные от клиента \t\n";
            }
            while (tcpSocket.Available > 0); // если полученные данные еще есть. цикл работает
            log += answer.ToString();  // сохраняем полученное сообщение

            Invoke((MethodInvoker)delegate { label1.Text = log; ; }); //вывод в лабел минуя ошибку 

           // tcpSocket.Shutdown(SocketShutdown.Both); //двухстроние закрытие соединение. на снервере и на клиенте
           // tcpSocket.Close();
        }
    }
}
