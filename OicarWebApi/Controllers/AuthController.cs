using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OicarWebApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OicarWebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly OicarAppDatabaseContext _context = new OicarAppDatabaseContext();

        // POST api/values
        [HttpPost]
        public async Task<int> CheckLoginData(string email, string passwordHash)
        {
            if(_context.AppUsers.FirstAsync(u => u.Email == email && u.PasswordHash.ToString() == passwordHash) != null){
                var user = await _context.AppUsers.FirstAsync(u => u.Email == email && u.PasswordHash.ToString() == passwordHash);
                return user.IdappUser;
            }
            else
            {
                return StatusCodes.Status401Unauthorized;
            }
        }



        
    }
}

