using Entity;
using Microsoft.EntityFrameworkCore;
using Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repositories
{
    public class UserRepo : IUserRepo
    {
        IDataSource dataSource;

         public UserRepo(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }

        public async Task<User> Add(User model)
        {
         var returnModel =  await dataSource.Users.AddAsync(model);
           await dataSource.SaveChangesAsync();
            return returnModel.Entity;
        }

        public async void Delete(int key)
        {
            dataSource.Users.Remove(await dataSource.Users.FindAsync(key));
            dataSource.SaveChangesAsync();
        }

        public async Task<List<User>> GetAll()
        {
            return await dataSource.Users.ToListAsync();
        }

         public async Task<User> GetById(int key)
        {
          return  await dataSource.Users.FindAsync(key);
        }

        public async void Update(User model)
        {
            var updateClaim = dataSource.Users.Update(model);
            dataSource.SaveChangesAsync();
        }
    }
}
