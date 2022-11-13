using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebFormApi.Data;
using WebFormApi.Models;

namespace WebFormApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    
    public class UserController : Controller
    {
        private readonly FullStackDbContext _fullStackDbContext;

        public UserController(FullStackDbContext fullStackDbContext)
        {
            _fullStackDbContext = fullStackDbContext;
        }

        [HttpGet]

        public async Task<IActionResult> GetAllUsers()
        {
         var users =  await  _fullStackDbContext.Users.ToListAsync();

            return Ok(users);
        }


        [HttpPost] 
        public async Task<IActionResult> AddUser([FromBody] User userRequest)
        {
            
            await _fullStackDbContext.Users.AddAsync(userRequest);
            await _fullStackDbContext.SaveChangesAsync();

            return Ok(userRequest);
        }
    }
}

