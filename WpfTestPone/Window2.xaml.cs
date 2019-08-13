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
    /// Логика взаимодействия для Window2.xaml
    /// </summary>
    public partial class Window2 : Window
    {
        string temSizeGrid = "";
        public Window2()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

               //метод при загрузке 
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
             temSizeGrid = $"Ширина:{MyGrid.ActualWidth}, Высота {MyGrid.ActualHeight}\t\n ";
            // lbMain.ItemsSource = testList3; // присваеваем в лист бокс с помощью имени листа через свойсто ресурсы lbMain.ItemsSource данные из колекции
            //lbMain.ItemsSource = new[] { new { lastName ="Иванов", firstName ="Ияван" },
            //                             new { lastName ="Петров", firstName ="Петр"},
            //                             new { lastName ="Сидоров", firstName ="Сидр"},
            //                             new { lastName ="кнремлке", firstName ="сумнрр" }

            //                                                                          }; 
            // присваеваем в лист бокс с помощью имени листа через свойсто ресурсы lbMain.ItemsSource данные из любой колекции.
        }

        //Кнопка при нажатии выход
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show(temSizeGrid);
            Close();
        }
    }
}
