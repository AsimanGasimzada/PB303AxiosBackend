using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PB303_API_Intro.Context;
using PB303_API_Intro.Models;
using System.Reflection.Metadata.Ecma335;

namespace PB303_API_Intro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UsersController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = await _context.Users.ToListAsync();

            return Ok(users);
        }


        [HttpPost]
        public async Task<IActionResult> CreateAsync(User user)
        {
            user.Id = 0;
            await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var user=await _context.Users.FindAsync(id);

            if (user is null)
                throw new Exception("Not found");

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
