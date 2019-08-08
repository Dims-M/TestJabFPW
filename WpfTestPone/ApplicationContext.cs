using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfTestPone
{
    class ApplicationContext : DbContext
    {
        /// <summary>
        /// Связь между программой и БД
        /// </summary>
        public ApplicationContext() : base("DefaultConnection2")
        {
        }
        //public ApplicationContext() : base("DefaultConnection2")
        //{
        //}
        public DbSet<Phone> Phones { get; set; }
        public DbSet<Catalog> Catalogs { get; set; }

    }
}
