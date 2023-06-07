using System;
namespace SoruCevap.Entities
{
	public class Soru:BaseEntity
	{
		public Guid SinavId { get; set; }
		//public Sinav Sinav { get; set; }


		public ICollection<Cevap> Cevaps { get; set; }
		public string SoruAciklamasi { get; set; }
		public decimal Puani { get; set; }
		public decimal Sure { get; set; }
		public int Siralama { get; set; }

		public Soru()
		{
		}
		public Soru(Guid sinavId,string aciklamasi,decimal puani,decimal suresi,int siralama)
		{
			Id = Guid.NewGuid();
			SoruAciklamasi = aciklamasi;
			SinavId = sinavId;
			Puani = puani;
			Sure = suresi;
			CreatedDate = DateTime.Now;
			IsActive = true;
			Siralama = siralama;
		}
	}
}

