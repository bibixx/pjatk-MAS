using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using mas_project.Models;
using mas_project.Models.DTOs.Responses;
using mas_project.Models.DTOs.Requests;

namespace mas_project.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private MainDbContext _context;

        public AuthController(MainDbContext context)
        {
            this._context = context;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDTORequest body)
        {
            User user = await this._context.Users
                .Where(u => u.UserName == body.UserName)
                .FirstOrDefaultAsync();

            if (user == null) {
                return StatusCode(401);
            }

            return Ok(new LoginDTOResponse {
                IdUser = user.IdUser,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email,
                Icon = user.Icon,
                IsSeller = user.IsSeller,
                IsBuyer = user.IsBuyer,
                SelfPickupAddress = user.IsSeller ? user.SelfPickupAddress : null,
                PhoneNumber = user.IsSeller ? user.PhoneNumber : null,
            });
        }
    }
}
