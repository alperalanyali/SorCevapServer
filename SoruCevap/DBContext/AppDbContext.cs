using System;
using Microsoft.EntityFrameworkCore;
using SoruCevap.Entities;

namespace SoruCevap.DBContext
{
	public class AppDbContext:DbContext
	{
		public AppDbContext()
		{
		}
        public AppDbContext(DbContextOptions<DbContext> options) : base(options)
        {

        }
        public DbSet<User> Users { get; set; }
		public DbSet<Soru> Sorus { get; set; }
		public DbSet<Sinav> Sinavs { get; set; }
		public DbSet<Cevap> Cevaps { get; set; }
        public DbSet<SinavSonuc> SinavSonucs { get; set; }
        public DbSet<CevapSonuc> CevapSonucs { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=SinavDB;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=False;User ID=sa;Password=metallica1;");
            }

        }

     
    }
}

