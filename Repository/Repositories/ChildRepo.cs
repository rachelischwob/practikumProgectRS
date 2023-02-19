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
    public class ChildRepo : IChildRepo
    {
        IDataSource dataSource;

        public ChildRepo(IDataSource dataSource)
        {
            this.dataSource = dataSource;
        }
        public async Task<Child> Add(Child model)
        {
               var returnModel = await dataSource.Childs.AddAsync(model);
            await dataSource.SaveChangesAsync();
            return returnModel.Entity;
        }

        public async void Delete(int key)
        {
            dataSource.Childs.Remove(await dataSource.Childs.FindAsync(key));
            dataSource.SaveChangesAsync();
        }
        public async Task<List<Child>> GetAll()
        {
            return await dataSource.Childs.ToListAsync();
        }
        public async Task<List<Child>> GetByParentId(int key)
        {
            List<Child> listAll = await this.GetAll();
            List<Child> listChilds = new List<Child>();
            foreach (var item in listAll)
            {
                if(item.ParentUser.Id == key)
                    listChilds.Add(item);
            }
            return listChilds;     
        }
        public async Task<Child> GetById(int key)
        {
            return await dataSource.Childs.FindAsync(key);
        }
        public async void Update(Child model)
        {
            var updateClaim = dataSource.Childs.Update(model);
            dataSource.SaveChangesAsync();
        }
    }
}
