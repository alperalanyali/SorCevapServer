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
    public class SoruController : ControllerBase
    {
        private readonly AppDbContext _dbContext;

        public SoruController(AppDbContext appDbContext)
        {
            _dbContext = appDbContext;
        }

        [HttpPost("CreateSoru")]
        public async Task<ActionResult> CreateSoru(string sinavId,string aciklamasi,decimal puani,int siralama,decimal suresi)
        {
            var soru = new Soru(Guid.Parse(sinavId), aciklamasi, puani, suresi,siralama);
            await _dbContext.Sorus.AddAsync(soru);
            await _dbContext.SaveChangesAsync();
            return Ok("Soru başarılı şekilde eklenmiştir");
        }

        [HttpPost("UpdateSoru")]
        public async Task<ActionResult> UpdateSoru(string id,string sinavId,string aciklama,decimal puani,decimal suresi,CancellationToken cancellationToken)
        {
            var soru = await _dbContext.Sorus.Where(p => p.Id == new Guid(id)).FirstOrDefaultAsync();
            soru.SinavId = new Guid(sinavId);
            soru.SoruAciklamasi = aciklama;
            soru.Puani = puani;
            soru.Sure = suresi;

            _dbContext.Update(soru);
            await _dbContext.SaveChangesAsync(cancellationToken);
            return Ok("Soru basarili sekilde guncellenmistir");
        }

        [HttpPost("DeleteSoru")]
        public async Task<ActionResult> DeleteSoru(string id,bool isActive,CancellationToken cancellationToken)
        {
            var soru = await _dbContext.Sorus.Where(p => p.Id == new Guid(id)).FirstOrDefaultAsync();
            soru.IsActive = isActive;
            _dbContext.Update(soru);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Ok("Soru pasife alinmistir");
        }
        [HttpPost("GetSoruBySinavIdandSiralama")]
        public async Task<ActionResult> GetSoruBySianvIdandSiralama(Guid sinavId,int siralama)
        {
            var soru = await _dbContext.Sorus.Where(p => p.SinavId == sinavId && p.Siralama == siralama).Include(p => p.Cevaps).FirstOrDefaultAsync();

            return Ok(soru);
        }

    }
}

