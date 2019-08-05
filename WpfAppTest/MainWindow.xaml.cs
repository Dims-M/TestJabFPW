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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAppTest
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //Обработчики событиий 
        
        /// <summary>
        /// При наведении курсова мыши на область
        /// </summary>
        /// <param name="sende"></param>
        /// <param name="e"></param>
        private void MouseEnter1(object sende, MouseEventArgs e)
        {
            (sende as Rectangle).Fill = Brushes.MediumPurple;
        }
        /// <summary>
        /// При выводе курсора мыши из области. 
        /// </summary>
        /// <param name="sende"></param>
        /// <param name="e"></param>
        private void MouseEnter2(object sende, MouseEventArgs e)
        {
           (sende as Rectangle).Fill = Brushes.Gold;
          // (sende as Rectangle).Fill = Brushes.Transparent;
        }

        private void ClickTest(object sende, RoutedEventArgs e)
        {
            (sende as Rectangle).Fill = Brushes.Gold;
            // (sende as Rectangle).Fill = Brushes.Transparent;
        }

    }
}
