using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class EgitimRepository : GenericRepository<TblEgitimlerim>
    {
        public EgitimRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
