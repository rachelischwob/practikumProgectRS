using Azure;
using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class Context : DbContext, IDataSource
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Child> Childs { get; set; }
        public int SaveChangesAsync()
        {
            return SaveChangesAsync();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=sqlsrv;Initial Catalog=Project-RS ;Integrated Security=True;TrustServerCertificate=True");
            base.OnConfiguring(optionsBuilder);
        }
    }
}
