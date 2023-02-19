using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Service.Interface;
using Service.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        IUserServ _service;
        public UserController(IUserServ service)
        {
            _service = service;
        }

        // GET: api/<UserController>
        [HttpGet]
        public async Task<List<UserModel>> Get()
        {
            return await _service.GetAll();
        }

        // GET api/<UserController>/5
        [HttpGet("{id}")]
        public async Task<UserModel> Get(int id)
        {
            return await _service.GetById(id);
        }
        // POST api/<UserController>
        [HttpPost]
        public async Task<UserModel> Post([FromBody] UserModel user)
        {
            UserModel u = new UserModel();
            ChildModel c = new ChildModel();
            if (user.Gender == 0)
                u.Gender = Service.Model.EGender.FEMALE;
            else
                u.Gender = Service.Model.EGender.MALE;
            u.NumberId = user.NumberId;
            u.LastName = user.LastName;
            u.FirstName = user.FirstName;
            u.DBO = user.DBO;
            u.HMO = user.HMO;
            if (user.Children != null)
            {
                u.Children=new List<ChildModel>();
                foreach (var item in user.Children)
                {
                    c.NumberId = item.NumberId;
                    c.Name = item.Name;
                    c.DOB = item.DOB;
                    u.Children?.Add(c);
                }
            }
            return await _service.Add(u);
        }

        // PUT api/<UserController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] UserModel user)
        {
            _service.Update(user);
        }

        // DELETE api/<UserController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _service.Delete(id);
        }
    }
}


