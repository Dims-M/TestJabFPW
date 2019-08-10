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
    public partial class ClientMenu : Form
    {
        /// <summary>
        /// для передачи из класса ClientMenu
        /// </summary>
        public Socket socket;

        public ClientMenu()
        {
            InitializeComponent();
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            Button buttonPressed = sender as Button;// создаем обьект типа кнопки и преобразуем его обьектос события 

            SendMenu sendMenu = new SendMenu();
            sendMenu.Action = buttonPressed.Text; // присвоиваем в переменную сстроки из формы SendMenu
            sendMenu.socket = socket;
            sendMenu.Show();
        }
    }
}
