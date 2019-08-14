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
using System.Threading;
using System.Threading.Tasks;

namespace ServerCodeBlog
{
    //https://www.youtube.com/watch?v=ZRGgBtUgJKE&t=1518s
    //https://metanit.com/sharp/net/4.1.php
    public partial class Form1 : Form
    {
        //Переменные
        const string ip = "192.168.1.54"; // д 192.168.0.45
        const int port = 19132;

        IPEndPoint tcpEndPoint;
        IPEndPoint updEndPoint;
        Socket tcpSocket;
        Socket upTcpSocket;
        Socket listener;

        string log = "Журнал событий \t\n";

        public Form1()
        {
            tcpEndPoint = new IPEndPoint(IPAddress.Parse(ip), port); //Точка подключения с серверу. могуть быть несколько
            tcpSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // точка подключения между программами.

            //Раббота с протоколом UDP
            updEndPoint = new IPEndPoint(IPAddress.Parse(ip),port);
            upTcpSocket = new Socket(AddressFamily.InterNetworkV6,SocketType.Stream,ProtocolType.Udp);

            InitializeComponent();
        }

      

        //При загрузке формы
        private async void Form1_Load(object sender, EventArgs e)
        {
            await Task.Run(() => InisalizaorFild());
            //InisalizaorFild();
        }

        //Методы

        /// <summary>
        /// Инициализатор поле и переменных в формате TCP
        /// </summary>
        public void InisalizaorFild()
        {   // режим ожидания
            tcpSocket.Bind(tcpEndPoint); // Связка точки доступа и сокета
            tcpSocket.Listen(5); // запус состояния прошлушивания
            log += "Запущен сокет на прошлушку \t\n";

            Invoke((MethodInvoker)delegate { label1.Text = log; ; }); // загружаем в таблицу данные полученнфые из листа

            while (true) //TODO можно реализовывать проверку спомощью булевой переменной
            {
                listener = tcpSocket.Accept(); // прошлушка сокета и при подключении создание нового скета для ответа
                var buffer = new byte[256]; // массив буфера
                var size = 0;
                var data = new StringBuilder();

                

                do // проверяем условие о получили запрос
                {
                    size = listener.Receive(buffer); // полученно все байти сообщения. Маскимальное  
                    data.Append(Encoding.UTF8.GetString(buffer, 0, size)); // добавляем полученые через сокет  раскадированное данные из бкфера
                    log += "Получены данные от клиента \t\n";
                }
                while (listener.Available > 0); // если полученные данные еще есть. цикл работает

                Invoke((MethodInvoker)delegate { label1.Text = data.ToString(); ; }); // загружаем в таблицу данные полученнфые из листа

               // label1.Text = data.ToString(); //выводим полученную инфу

                //Текущие сообщение сообщает об успешном соединении. В принципе можно отправлять и другие сообщения
                listener.Send(Encoding.UTF8.GetBytes("Успех")); //отправка сообщение через сокет что связь установленная. 

                //двухстроние закрытие соединение. на снервере и на клиенте
                //listener.Shutdown(SocketShutdown.Both);
                //listener.Close(); //физическое закрытие обьекта 
                //log += "Закрытие соединение \t\n";
                //Invoke((MethodInvoker)delegate { label1.Text += log; ; }); //вывод в лабел минуя ошибку 
               //Invoke((MethodInvoker)delegate { label1.Text += log; ; }); //вывод в лабел минуя ошибку 

            }

             
        }

        /// <summary>
        /// Метод запуска сокета в формате передачи UPD
        /// </summary>
        public void InisalizatorUPD()
        {
                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                     
        }


        //Кнопка выход
        private void Button1_Click(object sender, EventArgs e)
        {
            listener.Shutdown(SocketShutdown.Both);
            listener.Close(); //физическое закрытие обьекта 
            log += "Закрытие соединение \t\n";
            Close();
        }
    }
}
