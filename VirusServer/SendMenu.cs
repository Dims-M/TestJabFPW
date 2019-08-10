using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace VirusServer
{
    public partial class SendMenu : Form
    {
        /// <summary>
        /// Строка для передачи
        /// </summary>
        public string Action;
        public bool moreThanOneParameter;
        public Socket socket; // получаем сокет подключения из главной формы

        public SendMenu()
        {
            InitializeComponent();
        }

        //При загрузке формы
        private void SendMenu_Load(object sender, EventArgs e)
        {
            switch (Action)
            {
                case "Create":
                    firsrParameterLabel.Text = "Path"; // в лейбл указаваем путь
                    moreThanOneParameter = false;
                        break;
                case "Delete":
                    firsrParameterLabel.Text = "Path"; // в лейбл указаваем путь
                    moreThanOneParameter = false;
                    break;
                case "Rename":
                    firsrParameterLabel.Text = "Path"; // в лейбл указаваем путь
                    secondParameterLabel.Text = "Name";
                    moreThanOneParameter = true;
                    break;
            }

            if (!moreThanOneParameter)
            {//Проверяем. если пораметра 2 то 1 прячем
                secondParameterLabel.Hide();
                secontParameter.Hide();
            }


        }

        //Кнопка запуска
        private void SendButton_Click(object sender, EventArgs e)
        {
            string command = Action.ToLower(); //приводим в нижний регистр
            string request = command + "|" + firstParameter.Text + "|" + secontParameter.Text;
            byte[] buffer = Encoding.UTF8.GetBytes(request); //передаем команды в качестве строковых параметров
            socket.Send(buffer); // отправка данных через сокет
        }
    }
}
