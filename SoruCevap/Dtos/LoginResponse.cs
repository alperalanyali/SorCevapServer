using System;
namespace SoruCevap.Dtos
{
	public sealed record LoginResponse(
		string Email,
		string Name,
		string Surname,
		bool isAdmin,
		bool isAprove,
		Guid id
		);
	
}

