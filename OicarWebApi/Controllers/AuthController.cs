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
        public int CheckLoginData(string email, string passwordHash)
        {

            foreach (AppUser user in _context.AppUsers)
            {
                string p = Convert.ToBase64String(user.PasswordHash);
                char[] remList = { 'A', '='};
                p = p.TrimEnd(remList);
                if (user.Email == email && p == passwordHash) return user.IdappUser;
            }

            return -1;   

            
            
        }



        
    }
}

