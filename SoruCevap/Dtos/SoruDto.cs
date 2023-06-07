using System;
namespace SoruCevap.Dtos
{
	public class SoruDto
	{
		public Guid Id { get; set; }
		public string Aciklamasi { get; set; }
		public decimal Puani { get; set; }
		public decimal Suresi { get; set; }
		public List<CevapDto> CevapDtos { get; set; }

		public SoruDto()
		{

		}
		public SoruDto(Guid id,string aciklama,decimal puani,decimal suresi)
		{
			Id = id;
			Aciklamasi = aciklama;
			Puani = puani;
			Suresi = suresi;
		}
	}
}

