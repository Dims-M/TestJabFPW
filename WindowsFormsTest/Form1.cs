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
    public partial class Form1 : Form
    {
        private  Socket socket; // для связи по сети
        private byte[] buffer; //буфер для хранения полученной через стим и соукеты инфы
        MemoryStream stream; //Создает поток, резервным хранилищем которого является память.

        public Form1()
        {
            socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream,ProtocolType.Tcp ); // Создаем тип сокета с настройками соединения
            buffer = new byte[10000]; // временый буфер
            stream = new MemoryStream(buffer);
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

        }

        //Кнопка загрузить картинку
        private void Button1_Click(object sender, EventArgs e)
        {

        }

        //при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
