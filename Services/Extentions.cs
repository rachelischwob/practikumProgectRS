using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository.Interface;
using Repository.Repositories;
using Entity;
using Service.Model;
using Repository;

namespace Service
{
    public static class Extentions
    {
        public static void AddRepoDependencies(this IServiceCollection service)
        {
            service.AddScoped<IUserRepo, UserRepo>();
            service.AddScoped<IChildRepo, ChildRepo>();

            MapperConfiguration config = new MapperConfiguration(
                conf => { conf.CreateMap<User, UserModel>().ReverseMap(); conf.CreateMap<Child, ChildModel>().ReverseMap(); });

            IMapper mapper = config.CreateMapper();
            service.AddSingleton(mapper);

            service.AddDbContext<IDataSource,Context >();

        }
    }
}
