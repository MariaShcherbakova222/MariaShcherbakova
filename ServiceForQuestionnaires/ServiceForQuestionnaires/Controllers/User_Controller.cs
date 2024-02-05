using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServiceForQuestionnaires.Models;

namespace ServiceForQuestionnaires.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public databaseContext Context { get; }
        public UserController(databaseContext context)
        {
            Context = context;
        }

        private static List<User> Users = new List<User>();
        private readonly ILogger<databaseContext> _logger;

        public UserController(ILogger<databaseContext> logger)
        {
            _logger = logger;
        }

        // Регистрация пользователя
        [HttpPost("register")]
        public ActionResult RegisterUser([FromBody] User newUser)
        {
            if (newUser.Id < 0)
            {
                return BadRequest("Invalid user ID");
            }

            Users.Add(newUser);
            return Ok(newUser);
        }

        // Авторизация пользователя 
        [HttpPost("login")]
        public ActionResult LoginUser([FromBody] User loginUser)
        {
            var user = Users.FirstOrDefault(u => u.Email == loginUser.Email && u.Pasword == loginUser.Pasword);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }

        //поиск пользователя с помощью id
        [HttpGet("user/getID")]
        public IActionResult GetUser(int id)
        {
            var user = Users.FirstOrDefault(u => u.Id == id);
            if (user == null)
            {
                return NotFound("User not found");
            }

            return Ok(user);
        }
        //обновление информации пользователя
        [HttpPut("user/updateuser/{userId}")]
        public IActionResult UpdateUser(int userId, [FromBody] User user)
        {
            if (userId < 0 || user.Id < 0)
            {
                return BadRequest("Invalid user ID");
            }

            var existingUser = Users.FirstOrDefault(u => u.Id == userId);
            if (existingUser == null)
            {
                return NotFound("User not found");
            }

            existingUser.Namee = user.Namee;
            existingUser.Email = user.Email;
            existingUser.Pasword = user.Pasword;

            return Ok(existingUser);
        }
    }
}


