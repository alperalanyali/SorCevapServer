using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.DBContext;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoruCevap.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public UserController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        [HttpPost("GiveAprove")]
        public async Task<ActionResult> GiveAprove(Guid userId,CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.Where(p => p.Id == userId).FirstOrDefaultAsync();

            user.IsAprove = true;

            _dbContext.Update(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok("Onay verildi");
        }
        [HttpGet("GetUsers")]
        public async Task<ActionResult> GetAllUsers()
        {
            var users = await _dbContext.Users.ToListAsync();
            return Ok(users);
        }
    }
}

