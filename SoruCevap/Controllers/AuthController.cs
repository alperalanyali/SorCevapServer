using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoruCevap.DBContext;
using SoruCevap.Dtos;
using SoruCevap.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoruCevap.Controllers
{
    public class AuthController : ControllerBase
    {

        private readonly AppDbContext _dbContext;

        public AuthController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginRequest request
            )
        {
            var user =  _dbContext.Users.Where(p => p.Email == request.email && p.Password == request.password).FirstOrDefault();

            var loginResponse =  new LoginResponse(user.Email,user.Name,user.Surname,user.IsAdmin,user.IsAprove,user.Id);
            return Ok(loginResponse);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterRequest request,CancellationToken cancellationToken)
        {
            var user = new User(request.Email, request.Name, request.Surname, request.Password);
            await _dbContext.Users.AddAsync(user, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok("Kullanıcı başarılı şekilde yaratılmıştır");
        }

        




    }
}

