using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfAppTest.BD;

namespace WpfAppTest
{
    //Контекст для доступа к БД
    public class ApplicationContext : DbContext
    {
        
        public ApplicationContext():base("DefaultConnection") // настройка к строке подключения
        {

        }
        //Доступ к БД с помощью Енити фремворк
        public DbSet<Catalog> Catalogs { get; set; }
    }
}
