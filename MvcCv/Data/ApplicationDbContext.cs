using Microsoft.EntityFrameworkCore;
using MvcCv.Models.Entity;

namespace MvcCv.Data
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<TblAdmin> Admins { get; set; }
        public DbSet<TblDeneyimlerim> Deneyimlerim { get; set; }
        public DbSet<TblEgitimlerim> Egitimlerim { get; set; }
        public DbSet<TblHakkimda> Hakkimda { get; set; }
        public DbSet<TblHobilerim> Hobilerim { get; set; }
        public DbSet<TblIletisim> Iletisim { get; set; }
        public DbSet<TblSertifikalarim> Sertifikalarim { get; set; }
        public DbSet<TblYeteneklerim> Yeteneklerim { get; set; }

		public override int SaveChanges()
		{

			return base.SaveChanges();
		}

	}


}
