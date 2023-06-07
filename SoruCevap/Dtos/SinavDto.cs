using System;
namespace SoruCevap.Dtos
{
	public class SinavDto
	{
		public string SinavBasligi { get; set; }
		public string SinavAciklamasi { get; set; }

		public List<SoruDto> SoruDtos { get; set; }
	}
}

