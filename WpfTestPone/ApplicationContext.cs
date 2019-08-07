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
        public ApplicationContext() : base("DefaultConnection")
        {
        }
        public DbSet<Phone> Phones { get; set; }

    }
}
