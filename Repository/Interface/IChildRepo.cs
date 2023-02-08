using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Interface
{
    public interface IChildRepo :IRepo<Child>
    {
        Task<List<Child>> GetByParentId(int key);
    }
}
