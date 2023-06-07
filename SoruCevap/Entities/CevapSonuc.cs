using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace SoruCevap.Entities
{
	public class CevapSonuc:BaseEntity
	{
		
		public Guid SinavSonucId { get; set; }
		
		public Guid CevapId { get; set; }
		public Cevap Cevap { get; set; }

		public CevapSonuc()
		{

		}
		public CevapSonuc(string sinavSonucId,string cevapId)
		{
			Id = Guid.NewGuid();
			CreatedDate = DateTime.Now;
			SinavSonucId = new Guid(sinavSonucId);
			CevapId = new Guid(cevapId);


		}
	}
}

