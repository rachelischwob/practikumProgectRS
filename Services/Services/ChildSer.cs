using AutoMapper;
using Repository.Interface;
using Service.Interface;
using Service.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class ChildSer  /*:IChildServ*/
    {
        IChildRepo repo;
        IMapper imapper;
        public ChildSer(IChildRepo repo, IMapper imapper)
        {
            this.repo = repo;
            this.imapper = imapper;
        }

        //public async Task<ChildModel> Add(ChildModel model)
        //{
        //    throw new NotImplementedException();
        //}

        //public async void Delete(int key)
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<List<ChildModel>> GetAll()
        //{
        //    throw new NotImplementedException();
        //}

        //public async Task<ChildModel> GetById(int key)
        //{
        //    throw new NotImplementedException();
        //}

        //public async void Update(ChildModel model)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
