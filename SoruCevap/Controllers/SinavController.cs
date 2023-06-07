using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.DBContext;
using SoruCevap.Dtos;
using SoruCevap.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoruCevap.Controllers
{
    public class SinavController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public SinavController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }


        [HttpPost("AddSinav")]
        public async Task<ActionResult> AddSinav(string baslik,string aciklama,CancellationToken cancellationToken) {

            var sinav = new Sinav(baslik, aciklama);
            await _dbContext.Sinavs.AddAsync(sinav, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok();
        }
        [HttpPost("GetSinavById")]
        public async Task<ActionResult> GetSinavById(Guid id)
        { 
            var sinav = await _dbContext.Sinavs.Where(p => p.Id == id).Include(p => p.Sorus).ThenInclude(p => p.Cevaps).FirstOrDefaultAsync();
            return Ok(sinav);
        }

        [HttpGet("GetAllSinav")]
        public async Task<ActionResult> GetAllSinavs()
        {
           var sinavs = await _dbContext.Sinavs.Include(p => p.Sorus).ThenInclude(p => p.Cevaps).ToListAsync();

            return Ok(sinavs);
        }
    }
}

