using Azure;
using Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IDataSource
    {
       Task< int> SaveChangesAsync();
        int SaveChanges();
        DbSet<User> Users { get; set; }
       DbSet<Child> Childs { get; set; }
    }
}
