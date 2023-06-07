using System;
namespace SoruCevap.Entities
{
	public class Cevap:BaseEntity
	{

		public string Aciklama { get; set; }
		public bool IsCorrectAnswer { get; set; }

		public Guid SoruID { get; set; }
		//public Soru Soru { get; set; }


		public Cevap()
		{

		}

		public Cevap(string aciklama, bool isCorrectAnswer,Guid soruId)
		{
			Id = Guid.NewGuid();
			IsActive = true;
			CreatedDate = DateTime.Now;
			IsCorrectAnswer = isCorrectAnswer;
			Aciklama = aciklama;
			SoruID = soruId;
		}
	}
}

