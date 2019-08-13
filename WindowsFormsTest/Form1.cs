using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace WindowsFormsTest
{
    /// <summary>
    /// Класс отвечает за клиета
    /// </summary>
    public partial class Form1 : Form
    {
        //https://www.youtube.com/watch?v=uQcqAdhNjSk&t=624s
        private Socket socket; // для связи по сети
        private byte[] buffer; //буфер для хранения полученной через стим и соукеты инфы
        MemoryStream stream; //Создает поток, резервным хранилищем которого является память.
        int port = 19132;
        string ip = "92.168.0.45";  // 192.168.1.95 //92.168.0.45
        string log = "Журнал событий \t\n";

        public Form1()
        {
            //socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp ); // Создаем тип сокета с настройками соединения
            //buffer = new byte[10000]; // временый буфер
            //stream = new MemoryStream(buffer);
            StreamConnekt();
            InitializeComponent();
        }



        //Кнопка выхода
        private void Button3_Click(object sender, EventArgs e)
        {
            Close();
        }
        
        //Кнопка отправить
        private void Button2_Click(object sender, EventArgs e)
        {
            SendImageFile();
        }

        //Кнопка загрузить картинку
        private void Button1_Click(object sender, EventArgs e)
        {
            LoadFileImage();
        }

        //при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// инмцализация сокетов и запуск соединения
        /// </summary>
        public void StreamConnekt()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // Создаем тип сокета с настройками соединения
            
            stream = new MemoryStream();

            try
            {
                socket.Connect(ip,port); // вызываем сокет(соединение)
            }
            catch (Exception ex)
            {
                log = $"{DateTime.Now}\t\n Произошла ошибка при соединении сокета!!\t\n{ex}";
            }
        }

        /// <summary>
        /// Выбор и загрузка нужного файла в нужное окно
        /// </summary>
        public void LoadFileImage()
        {
            var fileDialog = new OpenFileDialog() // обьек для работы с формой диалога
            {
                Filter = "Выбрать все файлы: |*.jpg; *.phg; *.gif" // указываем какие типы файлов нам нужны 
            };

            fileDialog.ShowDialog(); //Показываем диалог пользователю
            pictureBox1.Image = Image.FromFile(fileDialog.FileName); // выгружаем нужный нам файл в оображение pictureBox1
        }

        /// <summary>
        /// Отправка файла через сокет
        /// </summary>
        public void SendImageFile()
        {
            if (pictureBox1 != null) // проверка
            {
                pictureBox1.Image.Save(stream,System.Drawing.Imaging.ImageFormat.Png); // указываем в какой поток сохранить из pictureBox1 и в какой форматте
                // так как стрим связан с буфером. до данные будут в нем.
                buffer = stream.ToArray(); // временый буфер  записываем нужный размер из стрима
                socket.Send(buffer); // отправка через сокет
            }
        }


    }
} 
