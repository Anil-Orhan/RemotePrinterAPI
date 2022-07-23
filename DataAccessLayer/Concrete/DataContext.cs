using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using EntityLayer.DTO;
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
        public DbSet<UserLogDto> UserLogs { get; set; }
        public DbSet<Option> Options { get; set; }
        public DbSet<Operation> Operations { get; set; }
        public DbSet<WalletActivity> WalletActivities { get; set; }
        public DbSet<Wallet> Wallets { get; set; }

    }
}
