using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BusinessLayer;
using System.Collections.Generic;
using DataLayer;
using API.DTOs;
using Microsoft.AspNetCore.Authorization;

namespace API.Controllers
{
    public class UserController : BaseApiController
    {
        private readonly DataContext _context;
        public UserController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("list")] 
        public async Task<ActionResult<IEnumerable<User>>> GetHeshan()
        {
          return await _context.Users.ToListAsync();
        }

        [HttpPost("insert")]
        [AllowAnonymous]
        public async Task<ActionResult> AddUser(UserDto userDto)
        {
            var user = new User
            {
                Name = userDto.Name,
                Address = userDto.Address
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return Ok(userDto);
        }
    }
}