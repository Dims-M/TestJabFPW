using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace WpfTestPone
{
    /// <summary>
    /// Логика взаимодействия для PhoneWindow.xaml
    /// </summary>
    public partial class PhoneWindow : Window
    {
        public Phone Phone { get; private set; }
        public Catalog Catalog { get; private set; }

        public PhoneWindow(Phone p)
        {
            InitializeComponent();
            Phone = p;
          //  this.DataContext = Phone;
        }

        public PhoneWindow(Catalog c)
        {
            InitializeComponent();
            Catalog = c;
            this.DataContext = Catalog;
        }
        private void Accept_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }
    }
}
