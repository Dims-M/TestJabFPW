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
using System.Net;
using System.Net.Sockets;


namespace VirusServer
{
    // https://www.youtube.com/watch?v=CG5eYP3NvuM&t=14s
    //https://www.youtube.com/watch?v=6rg5M0bBjBk&t=55s
    //https://metanit.com/sharp/net/3.2.php
    //https://www.youtube.com/watch?v=ZRGgBtUgJKE&t=1290s
    // https://habr.com/ru/post/462379/
    //192.168.0.45 порт 19132
    public partial class Form1 : Form
    {
        public Thread refreshThread; // отдельный поток
        public static Socket socket; // обьект для установки соединения
        public static List<Socket> clientList = new List<Socket>(); //лист для хранения клиентов
        System.Windows.Forms.Timer timer = new System.Windows.Forms.Timer(); //  тайймер


        public Form1()
        {
            InitializeComponent();
        }

        //при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry iPHostEntry =  Dns.Resolve(Dns.GetHostName()); // получаем имя текущего компа
            IPAddress iPAddress = iPHostEntry.AddressList[1]; // получаем айп адркс первого текущего компа
            int port = 19132;
            IPEndPoint endPoint = new IPEndPoint(iPAddress, port); //nj
            socket = new Socket(SocketType.Stream,ProtocolType.Tcp); // тип сокета и тип протокола свяязи
            socket.Bind(endPoint); //создание готового ссокета с нужными параметрами апи и порта
            socket.Listen(10); //Режим прошлушивания сокетом портов и ожидания прихода по ip + очередь
            refreshThread = new Thread(WaitForConnect);
            refreshThread.Start();// запуск метода в отдельном потоке

            //Дата и время
            timer.Interval = 1000; //интервал секунда
            timer.Tick += new EventHandler(Timer1_Tick);
            timer.Start(); //Виснет при закрытии

            timer2.Interval = 1000; //интервал секунда
            timer2.Tick += new EventHandler(Timer2_Tick);
            timer2.Start();

        }

        
        public  void WaitForConnect()
        {
            Socket client = socket.Accept(); //создание нового сокета 
            clientList.Add(client);
           Invoke((MethodInvoker) delegate { clientTable.DataSource = clientList; }); // загружаем в таблицу данные полученнфые из листа
        }

        //после закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshThread.Abort();// завершение потока
        }
        //при двойном клике
        private void ClientTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /// <summary>
            /// в сокет записываем значение из листа с выбранной строки
            /// </summary>
        //    Socket cur = clientList[e.RowIndex]; // в сокет записываем значение из листа с выбранной строки
        //    ClientMenu clientMenu = new ClientMenu();
        //    clientMenu.socket = cur;
        }

        private void ClientTable_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        //двойной клик мышки
        private void ClientTable_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            ///// <summary>
            ///// в сокет записываем значение из листа с выбранной строки
            ///// </summary>
            //Socket cur = clientList[e.RowIndex]; // в сокет записываем значение из листа с выбранной строки
            //ClientMenu clientMenu = new ClientMenu();
            //clientMenu.socket = cur;
        }

        private void ClientTable_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            /// <summary>
            /// в сокет записываем значение из листа с выбранной строки
            /// </summary>
            Socket cur = clientList[e.RowIndex]; // в сокет записываем значение из листа с выбранной строки
            ClientMenu clientMenu = new ClientMenu();
            clientMenu.socket = cur;
            clientMenu.Show(); // показ окна
        }
        int i;
        //метод работы с таймером
        /// <summary>
        /// Дата и время 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer1_Tick(object sender, EventArgs e)
        {
            int h = DateTime.Now.Hour;
            int m = DateTime.Now.Minute;
            int s = DateTime.Now.Second;

            string time = "";
            string data = "";

            if (h < 10)
            {
                time += "0" + h;
            }
            else
            {
                time += h;
            }

            time += ":";

            if (m < 10)
            {
                time += "0" + m;
            }
            else
            {
                time += m;
            }

            time += ":";

            if (s < 10)
            {
                time += "0" + s;
            }
            else
            {
                time += s;
            }

            label2.Text = time;

            int day = DateTime.Now.Day;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;

            if (day < 10)
            {
                data += "0" + day;
            }
            else
            {
                data += day;
            }
            data += ".";
            if (month < 10)
            {
                data += "0" + month;
            }
            else
            {
                data += month;
            }
            data += ".";
            data += year;
            label1.Text = data;

            ////Таймер работы програмы

            //i -= 1;
            //string mm;
            //string ss;
            //string hh = (i / 3600).ToString();
            //if ((i % 3600) / 60 > 9)
            //{
            //    mm = ((i % 3600) / 60).ToString();
            //}
            //else
            //{
            //    mm = "0" + ((i % 3600) / 60).ToString();
            //}
            //if ((i % 3600) % 60 > 9)
            //{
            //    ss = ((i % 3600) % 60).ToString();
            //}
            //else
            //{
            //    ss = "0" + ((i % 3600) % 60).ToString();
            //}
            //label3.Text = hh + ":" + mm + ":" + ss;
            //if (i < 0)
            //    timer1.Stop();
        }

        private void test()
        {
            i = 5400;
            label3.Text = "1:30:00";
            timer1.Interval = 1000;
            timer1.Enabled = true;
            timer1.Start();

        }

        private void Button1_Click(object sender, EventArgs e)
        {
          

         //   timer2.Enabled = true;
          //  timer2.Stop();
            // Close();
            socket.Close();
            this.Close();
        }

        /// <summary>
        /// Таймер отчета
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Timer2_Tick(object sender, EventArgs e)
        {
            //Таймер работы програмы
           // i = 5400;
            i -= 1;
            string mm;
            string ss;
            string hh = (i / 3600).ToString();
            if ((i % 3600) / 60 > 9)
            {
                mm = ((i % 3600) / 60).ToString();
            }
            else
            {
                mm = "0" + ((i % 3600) / 60).ToString();
            }
            if ((i % 3600) % 60 > 9)
            {
                ss = ((i % 3600) % 60).ToString();
            }
            else
            {
                ss = "0" + ((i % 3600) % 60).ToString();
            }
            label3.Text = hh + ":" + mm + ":" + ss;
            //if (i < 0)
            //    timer1.Stop();
        }
    }
}
