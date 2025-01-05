using MvcCv.Data;
using MvcCv.Models.Entity;

namespace MvcCv.Repositories
{
    public class SertifikaRepository : GenericRepository<TblSertifikalarim>
    {
        public SertifikaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
