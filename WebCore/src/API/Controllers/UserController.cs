using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using API.Models;

// For more information on enabling Web API for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        public UserController(IUserRepository Items)
        {
            UserItems = Items;
        }
        public IUserRepository UserItems { get; set; }

        [HttpGet]
        public IEnumerable<UserModel> GetAll()
        {
            return UserItems.GetAll();
        }

        [HttpGet("{id}", Name = "GetUser")]
        public IActionResult GetById(string id)
        {
            var item = UserItems.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return new ObjectResult(item);
        }
    }
}
