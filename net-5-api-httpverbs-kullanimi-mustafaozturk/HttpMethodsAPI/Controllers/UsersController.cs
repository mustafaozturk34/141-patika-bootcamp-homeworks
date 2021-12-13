using Microsoft.AspNetCore.Mvc;
using Models;
using System.Collections.Generic;
using System.Linq;

namespace HttpMethodsAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private static List<User> _users = new List<User>()
        {
            new User{
                UserID = 1,
                FirstName = "Name1",
                LastName = "Surname1",
                Mail = "mail1@gmail.com",
                PhoneNumber = "1234567890"
            },
            new User{
                UserID = 2,
                FirstName = "Name2",
                LastName = "Surname2",
                Mail = "mail2@gmail.com",
                PhoneNumber = "2345678901"
            },
            new User{
                UserID = 3,
                FirstName = "Name3",
                LastName = "Surname3",
                Mail = "mail3@gmail.com",
                PhoneNumber = "3456789012"
            },
            new User{
                UserID = 4,
                FirstName = "Name4",
                LastName = "Surname4",
                Mail = "mail4@gmail.com",
                PhoneNumber = "4567890123"
            },
            new User{
                UserID = 5,
                FirstName = "Name5",
                LastName = "Surname5",
                Mail = "mail5@gmail.com",
                PhoneNumber = "5678901234"
            },
    };

        [HttpGet]
        public List<User> Get()
        {
            var user = _users.ToList<User>();
            return user;
        }

        [HttpPost]
        public IActionResult Post([FromBody]User user)
        {
            if(_users.SingleOrDefault(x => x.Mail == user.Mail) != null)
            {
                return BadRequest();
            }
            _users.Add(user);
            return Ok();
        }

        [HttpPut]
        public IActionResult Put(int id, [FromBody] User user)
        {
            var updatedUser = _users.FirstOrDefault(u => u.UserID == id);
            if (updatedUser == null) { return BadRequest(); }
            updatedUser.FirstName = user.FirstName;
            updatedUser.LastName = user.LastName;
            updatedUser.PhoneNumber = user.PhoneNumber;
            updatedUser.Mail = user.Mail;
        
            return Ok();
        }

        [HttpDelete ("{id}")]
        public IActionResult Delete(int id)
        {
            var deletedUser = _users.FirstOrDefault(u => u.UserID == id);
            if (deletedUser == null) { return BadRequest();}
            _users.Remove(deletedUser);
            return Ok();
        }
    }
}
