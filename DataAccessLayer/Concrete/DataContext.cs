using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using File = EntityLayer.Concrete.File;

namespace DataAccessLayer.Concrete
{
    public class DataContext:DbContext
    {

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //Server bağlantısı
            optionsBuilder.UseSqlServer(@"Server=78.111.97.164; Database=PRINTOMI;  User=sa;Password=-azsxdcfv@N9; ");
        }

        public DbSet<User> Users { get; set; }
        public DbSet<PrintModel> PrintModels { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Printer> Printers { get; set; }
    }
}
