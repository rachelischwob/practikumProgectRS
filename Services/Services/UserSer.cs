using AutoMapper;
using Entity;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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
    public class UserSer : IUserServ
    {
        IUserRepo Urepo;
        IChildRepo Crepo;
        IMapper mapper;
        public UserSer(IUserRepo Urepo, IMapper mapper, IChildRepo Crepo)
        {
            this.Urepo = Urepo;
            this.Crepo = Crepo;
            this.mapper = mapper;
        }

        public async Task<UserModel> Add(UserModel model)
        {
            User tempU = await Urepo.Add(mapper.Map<User>(model));
            UserModel newUser = mapper.Map<UserModel>(tempU) ;
            newUser.Children = new List<ChildModel>();
            foreach (ChildModel item in model.Children)
            {
                Child tempC = mapper.Map<Child>(item);
                tempC.ParentUser = tempU;
                ChildModel c = mapper.Map<ChildModel>(await Crepo.Add(tempC));
                newUser.Children.Add(c);
            }
            return newUser;
        }
        public async void Delete(int key)
        {
            UserModel thisUser = mapper.Map<UserModel>(await Urepo.GetById(key));
            foreach (ChildModel item in thisUser.Children)
            {
                Crepo.Delete(item.Id);
            }
            Urepo.Delete(key);
        }

        public async Task<List<UserModel>> GetAll()
        {
            List<User> temp = await Urepo.GetAll();
            List<UserModel> list = new List<UserModel>();
            foreach (User item in temp)
            {
                UserModel tempUser = mapper.Map<UserModel>(item);
                tempUser.Children = await this.GetByParentId(tempUser.Id);
                list.Add(tempUser);
            }
            return list;
        }
        public async Task<List<ChildModel>> GetByParentId(int key)
        {
            List<Child> tempList = await Crepo.GetByParentId(key);
            List<ChildModel> listChilds = new List<ChildModel>();
            foreach (var item in tempList)
            {
                ChildModel c= mapper.Map<ChildModel>(item);
                listChilds.Add(c);
            }
            return listChilds;
        }

        public async Task<UserModel> GetById(int key)
        {
            UserModel user = mapper.Map<UserModel>(await Urepo.GetById(key));
            if(user!=null)
            user.Children = await GetByParentId(user.Id);
            return user;
        }

        public async void Update(UserModel model)
        {
            UserModel thisUser = mapper.Map<UserModel>(await Urepo.GetById(model.Id));
            foreach (ChildModel item in thisUser.Children)
            {
                Crepo.Update(mapper.Map<Child>(item));
            }
            Urepo.Update(mapper.Map<User>(model));
        }
    }
}
