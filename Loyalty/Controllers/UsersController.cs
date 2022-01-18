using Loyalty.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Loyalty.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<Users> User = new List<Users>();

        private readonly MyDbContext _context;

        public UsersController(MyDbContext context)
        {
            _context = context;
        }

        [HttpGet] // Get users

        //public IActionResult GetAll()
        //{
        //    return Ok(User);
        //}
        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpGet("{id}")] //find user with id.

        public IActionResult GetById(string id)
        {
            try
            {
                var user = User.SingleOrDefault(user => user.ID == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpPost] //create users

        //public IActionResult Create(Users users)
        //{
        //    var user = new Users
        //    {
        //        ID = Guid.NewGuid(), //random id
        //        Email = users.Email,
        //        Password = users.Password,
        //        Username = users.Username,
        //    };
        //    User.Add(user);
        //    return Ok(new
        //    {
        //        Success = true, Data = user
        //    }); ;
        //}

        public async Task<ActionResult<List<Users>>> Add (Users users)
        {
            _context.User.Add(users);
            await _context.SaveChangesAsync();
            return Ok(await _context.User.ToListAsync());
        }

        [HttpPut("{id}")] //edit users

        public IActionResult Edit (string id, Users usersEdit)
        {
            try
            {
                var user = User.SingleOrDefault(user => user.ID == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                if (id != user.ID.ToString())
                {
                    return BadRequest();
                }
                user.Username = usersEdit.Username;
                user.Email = usersEdit.Email;
                user.Password = usersEdit.Password;
                return Ok(user);
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")] //delete users
        public IActionResult Delete(string id)
        {
            try
            {
                var user = User.SingleOrDefault(user => user.ID == Guid.Parse(id));
                if (user == null)
                {
                    return NotFound();
                }
                User.Remove(user);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
