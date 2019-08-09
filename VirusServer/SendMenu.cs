using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VirusServer
{
    public partial class SendMenu : BaseSendMenu
    {
        /// <summary>
        /// Строка для передачи
        /// </summary>
        public string Action;
        public SendMenu()
        {
            InitializeComponent();
        }


        private void SendMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
