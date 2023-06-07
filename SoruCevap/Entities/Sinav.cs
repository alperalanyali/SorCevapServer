using System;
namespace SoruCevap.Entities
{
	public class Sinav:BaseEntity
	{

		public string Baslik { get; set; }
		public string Aciklama { get; set; }


		//public List<Soru> Sorus { get; set; }
		public ICollection<Soru> Sorus { get; set; }
		public Sinav()
		{

		}
		public Sinav(string baslik,string aciklama)
		{
			Id = Guid.NewGuid();
			Baslik = baslik;
			Aciklama = aciklama;
			IsActive = true;
			CreatedDate = DateTime.Now;
		}
	}
}

