using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SoruCevap.DBContext;
using SoruCevap.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoruCevap.Controllers
{
    public class SinavSonucController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public SinavSonucController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        [HttpPost("SaveSinavSonuc")]
        public async Task<ActionResult> SaveSinavSonuc(string sinavId,string userId,CancellationToken cancellationToken)
        {
            var sinavSonuc = new SinavSonuc(userId, sinavId);
            await _dbContext.SinavSonucs.AddAsync(sinavSonuc, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok("Sınav başarılı şekilde başlanmıştır");
        }
    }
}

