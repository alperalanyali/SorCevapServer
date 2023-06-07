using System;
namespace SoruCevap.Entities
{
	public class SinavSonuc:BaseEntity
	{
		public Guid UserId { get; set; }
		public User User { get; set; }

		public Guid SinavId { get; set; }
		public Sinav Sinav { get; set; }

		public SinavSonuc()
		{

		}
		public SinavSonuc(string userId,string sinavId)
		{
			Id = Guid.NewGuid();
			CreatedDate = DateTime.Now;
			UserId = new Guid(userId);
			SinavId = new Guid(sinavId);
		}
	}
}

