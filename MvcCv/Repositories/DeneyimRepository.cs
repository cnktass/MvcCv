using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class DeneyimRepository : GenericRepository<TblDeneyimlerim>

    {
        public DeneyimRepository(ApplicationDbContext context) : base(context)
        {
        }


    }
}
