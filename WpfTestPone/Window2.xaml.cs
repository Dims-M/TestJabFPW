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
        
        public Window2()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        List<string> testList = new List<string>() {"Bdgtvt","servwcc","vhryhtyhcwect" };
        List<string> testList1 = new List<string>() {"Bdgtvt","servwcc","vhryhtyhcwect" };
        List<string> testList2 = new List<string>() {"Bdgtvt","servwcc","vhryhtyhcwect" };
        List<string> testList3 = new List<string>();
        


        //метод при загрузке 
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            // throw new NotImplementedException();
            testList3.AddRange(testList);
            testList3.AddRange(testList1);
            testList3.AddRange(testList2);

            lbMain.ItemsSource = testList3; // присваеваем в лист бокс с помощью имени листа через свойсто ресурсы lbMain.ItemsSource данные из колекции
        }
    }
}
