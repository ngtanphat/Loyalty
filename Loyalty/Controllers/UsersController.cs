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

        public async Task<ActionResult<List<Users>>> Get()
        {
            return Ok(await _context.User.ToListAsync());
        }

        [HttpGet("{id}")] //find user with id.

        public async Task<ActionResult<List<Users>>> GetById(Guid id)
        {
                var user = await _context.User.FindAsync(id);
                if (user == null)
                    return BadRequest("user not found");
                return Ok(user);
        }

        [HttpPost] //create users


        public async Task<ActionResult<List<Users>>> Add (Users users)
        {
            _context.User.Add(users);
            var existingUser = await _context.User.FindAsync(users.Username);
            if (existingUser != null)
            {
                return BadRequest("User available");
            }
            await _context.SaveChangesAsync();
            return Ok(await _context.User.ToListAsync());
        }

        [HttpPut("{id}")] //edit users

        public async Task<ActionResult<List<Users>>> Edit (Users usersEdit)
        {
            try
            {
                var user = await _context.User.FindAsync(usersEdit.ID);
                if (user == null)
                    return BadRequest("User not found");

                user.Email = usersEdit.Email;
                user.Username = usersEdit.Username;
                user.Password = usersEdit.Password;

                await _context.SaveChangesAsync();
                return Ok(await _context.User.ToListAsync());
            }
            catch
            {
                return BadRequest();
            }
        }

        [HttpDelete("{id}")] //delete users
        
        public async Task<ActionResult<List<Users>>> Delete(Users deleteUser)
        {
            var user = await _context.User.FindAsync(deleteUser.ID);
            if (user == null)
                return BadRequest("User not found");
            _context.User.Remove(user);
            await  _context.SaveChangesAsync();
            return Ok(await _context.User.ToListAsync());
        }
    }
}
