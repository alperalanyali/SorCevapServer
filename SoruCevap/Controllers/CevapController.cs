using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SoruCevap.DBContext;
using SoruCevap.Entities;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SoruCevap.Controllers
{
    public class CevapController : ControllerBase
    {
        private readonly AppDbContext _dbContext;
        public CevapController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }
        [HttpPost("Create")]
        public async Task<ActionResult> CreateCevap(string soruId,string aciklamasi,bool isCorrectAnswer,CancellationToken cancellationToken)
        {
            var cevap = new Cevap(aciklamasi,isCorrectAnswer,new Guid(soruId));
            await _dbContext.Cevaps.AddAsync(cevap, cancellationToken);
            await _dbContext.SaveChangesAsync();
            return Ok("Cevap basarili sekilde eklenmiştir");

        }
        [HttpPost("UpdateCevap")]
        public async Task<ActionResult> UpdateCevap(string id,string sorudId,string aciklamasi,bool isCorrectAnswer,CancellationToken cancellationToken)
        {
            var cevap = await _dbContext.Cevaps.Where(p => p.Id == new Guid(id)).FirstOrDefaultAsync();
            cevap.Aciklama = aciklamasi;
            cevap.SoruID = new Guid(sorudId);
            cevap.IsCorrectAnswer = isCorrectAnswer;

            _dbContext.Cevaps.Update(cevap);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok("Cevap basarili sekilde guncellenmistir");
        }

        public async Task<ActionResult> DeleteCevap(string id)
        {
            var cevap = await _dbContext.Cevaps.Where(p => p.Id == new Guid(id)).FirstOrDefaultAsync();
            cevap.IsActive = false;

            return Ok("Cevap basarili sekilde silinmistir");
        }
        [HttpGet("GetAllCevaps")]
        public async Task<ActionResult> GetAllCevap()
        {
            var cevaps = await _dbContext.Cevaps.ToListAsync();
            return Ok(cevaps);
        }
    }
}

