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
   
    public partial class Form1 : Form
    {
        public Thread refreshThread; // отдельный поток
        public static Socket socket; // обьект для установки соединения
        public static List<Socket> clientList; //лист для хранения клиентов


        public Form1()
        {
            InitializeComponent();
        }

        //при загрузке формы
        private void Form1_Load(object sender, EventArgs e)
        {
            IPHostEntry iPHostEntry =  Dns.Resolve(Dns.GetHostName()); // получаем имя текущего компа
            IPAddress iPAddress = iPHostEntry.AddressList[0]; // получаем айп адркс первого текущего компа
            int port = 19132;
            IPEndPoint endPoint = new IPEndPoint(iPAddress, port); //nj
            socket = new Socket(SocketType.Stream,ProtocolType.Tcp); // тип сокета и тип протокола свяязи
            socket.Bind(endPoint); //создание готового ссокета с нужными параметрами апи и порта

            refreshThread = new Thread(WaitForConnect);
            refreshThread.Start();// запуск метода в отдельном потоке
        }

        
        public  void WaitForConnect()
        {
            Socket client = socket.Accept(); //создание нового сокета 
            clientList.Add(client);
            clientTable.DataSource = clientList; // загружаем в таблицу данные полученнфые из листа
        }

        //после закрытия формы
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            refreshThread.Abort();// завершение потока
        }
        //при двойном клике
        private void ClientTable_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            Socket cur = clientList[e.RowIndex]; // в сокет записываем значение из листа с выбранной строки
        }
    }
}
