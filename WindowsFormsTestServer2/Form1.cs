using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Sockets;
using System.Net;
using System.IO;

namespace WindowsFormsTestServer2
{
    // https://www.youtube.com/watch?v=uQcqAdhNjSk&t=624s
    public partial class Form1 : Form
    {
        int port = 19132;
        Socket client; // клиенский сокет
        Socket socket;

        byte[] buffer;
        MemoryStream stream;


        public Form1()
        {
            // ListenonnnetServer();
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Создаем тип сокета с настройками соединения
            buffer = new byte[100000]; // временый буфер
            stream = new MemoryStream(buffer);
            EnableFileServer();

            InitializeComponent();
        }

        /// <summary>
        /// Метод конекта сокетов
        /// </summary>
        private void ListenonnnetServer()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Создаем тип сокета с настройками соединения
            buffer = new byte[100000]; // временый буфер
            stream = new MemoryStream(buffer);
        }

        /// <summary>
        /// Включение запуска и  прошлушки сервера
        /// </summary>
        private void EnableFileServer()
        {
            socket.Bind(new IPEndPoint(IPAddress.Any, port)); // создаем току соединения
            socket.Listen(10);
        }

        /// <summary>
        /// Соединение с клиентом
        /// </summary>
        private void LoadFileToServer()
        {
            socket.Accept(); // создание подклчение и запуска нового сокета
            label1.Text = "Соединение установленно";
           
            socket.Receive(buffer);
            label1.Text = "Новые данные получены";
            pictureBox1.Image = Image.FromStream(stream);
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            stream.Close();
            Close();
        }

        //Запуск соединения
        private void Button1_Click(object sender, EventArgs e)
        {
            LoadFileToServer(); 
        }

        //Получение файла
        private void Form1_Load(object sender, EventArgs e)
        {
            //socket.Receive(buffer);
            //label1.Text = "Новые данные получены";
            //pictureBox1.Image = Image.FromStream(stream);
          //  stream.Close();
        }
    }
}
