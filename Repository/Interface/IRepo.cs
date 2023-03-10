using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IRepo<T>
    {
        Task<T> Add(T model);
        void Update(T model);
        void Delete(int key);
        Task<T> GetById(int key);
        Task<List<T>> GetAll();
    }
}
