using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class IletisimRepository : GenericRepository<TblIletisim>
    {
        public IletisimRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
