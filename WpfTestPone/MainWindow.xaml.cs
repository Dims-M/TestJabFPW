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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfTestPone
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ApplicationContext db;
        ApplicationContext db2;
        public MainWindow()
        {
            InitializeComponent();
            //  InitializeComponent();

            db = new ApplicationContext();
            db2 = new ApplicationContext();
           // db.Phones.Load();
            db2.Catalogs.Load();
            //this.DataContext = db.Phones.Local.ToBindingList();
          //  this.DataContext = db2.Catalogs.Local.ToBindingList();
        }

            // добавление
            private void Add_Click(object sender, RoutedEventArgs e)
            {
                PhoneWindow phoneWindow = new PhoneWindow(new Phone());
                if (phoneWindow.ShowDialog() == true)
                {
                    Phone phone = phoneWindow.Phone;
                    db.Phones.Add(phone);
                    db.SaveChanges();
                }
            }
            // редактирование
            private void Edit_Click(object sender, RoutedEventArgs e)
            {
                // если ни одного объекта не выделено, выходим
                if (phonesList.SelectedItem == null) return;
                // получаем выделенный объект
                Phone phone = phonesList.SelectedItem as Phone;

                PhoneWindow phoneWindow = new PhoneWindow(new Phone
                {
                    Id = phone.Id,
                    Company = phone.Company,
                    Price = phone.Price,
                    Title = phone.Title
                });

                if (phoneWindow.ShowDialog() == true)
                {
                    // получаем измененный объект
                    phone = db.Phones.Find(phoneWindow.Phone.Id);
                    if (phone != null)
                    {
                        phone.Company = phoneWindow.Phone.Company;
                        phone.Title = phoneWindow.Phone.Title;
                        phone.Price = phoneWindow.Phone.Price;
                        db.Entry(phone).State = EntityState.Modified;
                        db.SaveChanges();
                    }
                }
            }
            // удаление
            private void Delete_Click(object sender, RoutedEventArgs e)
            {
                // если ни одного объекта не выделено, выходим
                if (phonesList.SelectedItem == null) return;
                // получаем выделенный объект
                Phone phone = phonesList.SelectedItem as Phone;
                db.Phones.Remove(phone);
                db.SaveChanges();
            }

        //кнопка показать все товары
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Window1 window1 = new Window1();
            window1.Show();
        }

        //кнопка тест
        private void Button_Click1(object sender, RoutedEventArgs e)
        {
            Window2 window2 = new Window2();
            window2.Show();
        }

        private void Button_ClickExit(object sender, RoutedEventArgs e)
        {
            this.Close();
            // MainWindow.Ex
        }
    }
}
