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
    public class CevapSonucController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CevapSonucController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        [HttpPost("SaveCevapSonuc")]
        public async Task<ActionResult> SaveCevapSonuc(string sinavSonucId,string cevapId,CancellationToken cancellationToken)
        {
            var cevapSonuc = new CevapSonuc(sinavSonucId, cevapId);
            await _dbContext.CevapSonucs.AddAsync(cevapSonuc, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok("OKkk");
        }
    }
}

