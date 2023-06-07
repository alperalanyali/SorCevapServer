using System;
namespace SoruCevap.Entities
{
	public class BaseEntity
	{
		public Guid Id { get; set; }
		public DateTime CreatedDate { get; set; }
		public bool IsActive { get; set; }

	}
}

