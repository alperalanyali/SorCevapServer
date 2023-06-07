﻿using System;
namespace SoruCevap.Entities
{
	public class User:BaseEntity
	{
		public string Email { get; set; }
		public string Name { get; set; }
		public string Surname { get; set; }
		public string Password { get; set; }
		public bool IsAdmin { get; set; } = false;
		public bool IsAprove { get; set; }

		public User()
		{

		}
		public User(string email,string name,string surname,string password)
		{
			Id = Guid.NewGuid();
			Email = email;
			Name = name;
			Surname = surname;
			Password = password;
			CreatedDate = DateTime.Now;
			IsActive = true;
			IsAprove = false;
		}
	}
}

