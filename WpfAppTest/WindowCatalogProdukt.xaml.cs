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
using WpfAppTest.BD;

namespace WpfAppTest
{
    /// <summary>
    /// Логика взаимодействия для WindowCatalogProdukt.xaml
    /// </summary>
    public partial class WindowCatalogProdukt : Window
    {
        ApplicationContext db;


        public Catalog catalog { get; private set; } //Связь с БД

        public WindowCatalogProdukt()
        {
            InitializeComponent();

            db = new ApplicationContext();
            db.Catalogs.Load(); // Загрузка из таблиц БД
            this.DataContext = db.Catalogs.Local.ToBindingList();

            catalog = new Catalog();
            this.DataContext = catalog; // 
        }
        
        // добавление
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            PhoneWindow phoneWindow = new PhoneWindow(new Catalog());
            if (phoneWindow.ShowDialog() == true)
            {
                Catalog phone = phoneWindow.catalog;
                db.Catalogs.Add(phone);
                db.SaveChanges();
            }
        }
        // редактирование
        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            // если ни одного объекта не выделено, выходим
            if (phonesList.SelectedItem == null) return;
            // получаем выделенный объект
            Catalog phone = phonesList.SelectedItem as Catalog;

            PhoneWindow phoneWindow = new PhoneWindow(new Catalog
            {
                Id = phone.Id,
                FullName = phone.FullName,
                AlcCode = phone.AlcCode,
                Price = phone.Price
            }) ;

            if (phoneWindow.ShowDialog() == true)
            {
                // получаем измененный объект
                phone = db.Catalogs.Find(phoneWindow.catalog.Id);
                if (phone != null)
                {
                    phone.FullName= phoneWindow.catalog.FullName;
                    phone.AlcCode = phoneWindow.catalog.AlcCode;
                    phone.Price = phoneWindow.catalog.Price;
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
            Catalog phone = phonesList.SelectedItem as Catalog;
            db.Catalogs.Remove(phone);
            db.SaveChanges();
        }
    }
}

