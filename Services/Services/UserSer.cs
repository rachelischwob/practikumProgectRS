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
            User tempUser = new User
            {
                Id = model.Id,
                FirstName = model.FirstName,
                LastName = model.LastName,
                NumberId = model.NumberId,
                HMO = model.HMO,
                Gender = (Entity.EGender)model.Gender,
                DBO = model.DBO,
            };
            tempUser = (await Urepo.Add(tempUser));
            if(model.Children != null)
            {
            foreach (ChildModel item in model.Children)
            {
                    Child c = new Child
                    {
                        Id = item.Id,
                        Name = item.Name,
                        DOB = item.DOB,
                        NumberId = item.NumberId,
                        ParentUser = tempUser,
                    };
                c = await Crepo.Add(c);
                item.Id=c.Id;
                    item.ParentUserId=tempUser.Id;
            }

            }
            model.Id = tempUser.Id;
            return model;
        }

        //public async Task<UserModel> Add(UserModel model)
        //{

        //    UserModel newUser= mapper.Map <UserModel>( await Urepo.Add(mapper.Map<User>(model)));
        //    foreach (ChildModel item in model.Children)
        //    {
        //        item.ParentUserId = newUser.Id;
        //        ChildModel c= mapper.Map<ChildModel>(await Crepo.Add(mapper.Map<Child>(item)));
        //        newUser.Children.Add(c);
        //    }
        //    return newUser;
        //}
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
                tempUser.Children = await GetByParentId(tempUser.Id);
            }
            return list;
        }
        public async Task<List<ChildModel>> GetByParentId(int key)
        {
            List<Child> tempList = await Crepo.GetByParentId(key);
            List<ChildModel> listChilds = new List<ChildModel>();
            foreach (var item in tempList)
            {
                listChilds.Add(mapper.Map<ChildModel>(item));
            }
            return listChilds;
        }

        public async Task<UserModel> GetById(int key)
        {
            UserModel user = mapper.Map<UserModel>(await Urepo.GetById(key));

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
