using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfAppTest.BD
{
    /// <summary>
    /// Класс описывающий в БД каталог с товарами
    /// </summary>
   public class Catalog : INotifyPropertyChanged
    {
        private string fullName;
        private string alcCode;
        private double price;
        private string created;


        public int Id { get; set; }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("Название товара");
            }
        }

        public string AlcCode
        {
            get { return alcCode; }
            set
            {
                alcCode = value;
                OnPropertyChanged("Алкокод");
            }
        }

        public string Price
        {
            get { return price.ToString(); }
            set
            {
                price = Convert.ToDouble( value); // конвер в дабл
                OnPropertyChanged("Цена");
            }
        }

        public string Created
        {
            get { return created; }
            set
            {
                created = value;
                OnPropertyChanged("дата создания товара");
            }
        }

        //МЕТОДЫ
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
