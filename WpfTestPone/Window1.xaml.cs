using System;
using System.Collections.Generic;
using System.Data.Entity;
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
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        ApplicationContext db; // для связи с БД

        public Window1()
        {
            db = new ApplicationContext();
            InitializeComponent();
            db.Catalogs.Load(); // Закгрузка все базы в локальный кэш.
            DataContext = db.Catalogs.Local.ToBindingList();

        }



        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PhoneWindow phoneWindow = new PhoneWindow(new Catalog());
            if (phoneWindow.ShowDialog() == true)
            {
                Catalog catalog = phoneWindow.Catalog;
                db.Catalogs.Add(catalog);
                db.SaveChanges();
                // }
            }
        }


    }
}
