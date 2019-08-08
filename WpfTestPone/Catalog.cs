using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestPone
{
    public class Catalog
    {
        private string fullName;
        private string alcCode;
        private float price;

        [Key]
      public  int Id { set; get; }

        public string FullName
        {
            get { return fullName; }
            set
            {
                fullName = value;
                OnPropertyChanged("FullName");
            }
        }


        public string AlcCode
        {
            get { return alcCode; }
            set
            {
                alcCode = value;
                OnPropertyChanged("alcCode");
            }
        }

        public float Price
        {
            get { return price; }
            set
            {
                price = value;
                OnPropertyChanged("price");
            }
        }
 

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
